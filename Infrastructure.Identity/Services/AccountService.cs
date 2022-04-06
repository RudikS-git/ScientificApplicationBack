using App.Common.Interfaces;
using App.Common.Models;
using Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using MapsterMapper;
using App.Users.DTOs;
using Domain.Entities.Enums;
using Microsoft.AspNetCore.WebUtilities;
using App.Email.DTOs;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services
{
    public class AccountService : IAccountService
    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ITokenService _tokenService;
        private readonly IEmailService _emailService;
        private readonly ICurrentUserService _userService;

        private readonly IApplicationContext _applicationContext;

        public AccountService(IApplicationContext applicationContext,
            UserManager<User> userManager, 
            SignInManager<User> signInManager,
            IMapper mapper, 
            ITokenService tokenService,
            IEmailService emailService,
            ICurrentUserService userService)
        {
            _userManager = userManager;
            _mapper = mapper;
            _tokenService = tokenService;
            _signInManager = signInManager;
            _emailService = emailService;
            _userService = userService;

            _applicationContext = applicationContext;
        }

        public async Task<ServiceResult<AuthenticationResponse>> AuthenticateAsync(AuthenticationRequest authenticateModel, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(authenticateModel.Email);

            if(user == null)
            {
                return ServiceResult.Failed<AuthenticationResponse>(new ServiceError("Пользователь с таким E-mail не существует", 400));
            }

            var result = await _signInManager.PasswordSignInAsync(user, authenticateModel.Password, true, true);

            if (!result.Succeeded)
            {
                return ServiceResult.Failed<AuthenticationResponse>(new ServiceError("Неверно введена почта или пароль", 400));
            }
            else
            {
                var roles = await _userManager.GetRolesAsync(user);
                var accessToken = _tokenService.CreateJwtSecurityToken(user, roles);
                var refreshToken = await GenerateSaveRefreshToken(user, cancellationToken);

                var response = new AuthenticationResponse()
                {
                    Id = user.Id,
                    Email = user.Email,
                    AccessToken = accessToken,
                    RefreshToken = refreshToken.Token
                };

                return ServiceResult.Success(response);
            }
        }

        public async Task<ServiceResult> RegisterAsync(RegisterRequest registerModel, CancellationToken cancellationToken)
        {
            var userWithSameEmail = await _userManager.FindByEmailAsync(registerModel.Email);

            if (userWithSameEmail != null)
            {
                return ServiceResult.Failed(new ServiceError("Пользователь с таким E-mail уже существует", 400));
            }

            var user = new User()
            {
                Email = registerModel.Email,
                UserName = registerModel.Email
            };

            var result = await _userManager.CreateAsync(user, registerModel.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, RolesEnum.User.ToString());
                /*var verificationUri = await SendVerificationEmail(user, "https://some-sity.ru");

                await _emailService.SendAsync(new EmailRequest()
                {
                    From = "scientific-portal@mail.ru",
                    To = user.Email,
                    Body = $"Please confirm your account by visiting this URL {verificationUri}",
                    Subject = "Confirm Registration"
                });*/
            }
            else
            {
                // заменить на result.Errors
                return ServiceResult.Failed(new ServiceError("Не удалось создать пользователя", 400));
            }

            return ServiceResult.Success(result);
        }

        public Task<ServiceResult> ConfirmEmail(ConfirmEmailRequest confirmEmailRequest, CancellationToken cancellationToken)
        { 
            throw new NotImplementedException();
        }

        public Task<ServiceResult> ForgotPassword(ForgotPasswordRequest forgotPasswordRequest, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult> ResetPassword(ResetPasswordRequest resetPasswordRequest, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResult<RefreshTokenResponse>> RefreshToken(string refreshToken, CancellationToken cancellationToken)
        {
            var user = _applicationContext.Users.SingleOrDefault(u => u.RefreshTokens.Any(it => it.Token == refreshToken));

            if (user == null)
            {
                return ServiceResult.Failed<RefreshTokenResponse>(ServiceError.NotFound);
            }

            var roles = await _userManager.GetRolesAsync(user);
            var accessToken = _tokenService.CreateJwtSecurityToken(user, roles);
            var refreshTokenEntity = await GenerateSaveRefreshToken(user, cancellationToken);

            return ServiceResult.Success(new RefreshTokenResponse() {
                AccessToken = accessToken,
                RefreshToken = refreshTokenEntity.Token
            });
        }

        public async Task<ServiceResult> RevokeRefreshToken(string refreshToken, CancellationToken cancellationToken)
        {
            var user = _applicationContext.Users.Include(it => it.RefreshTokens).SingleOrDefault(u => u.RefreshTokens.Any(it => it.Token == refreshToken));
            
            if (user == null)
            {
                return ServiceResult.Failed(ServiceError.NotFound);
            }

            var refreshTokenEntity = user.RefreshTokens.Single(it => it.Token == refreshToken);

            if (!refreshTokenEntity.IsActive)
            {
                return ServiceResult.Failed(ServiceError.CustomMessage("Данный токен уже истёк или был отозван"));
            }

            refreshTokenEntity.Revoked = DateTime.UtcNow;
            refreshTokenEntity.RevokedByIp = _userService.IpAddress;
            refreshTokenEntity.ReplacedByToken = refreshToken;
            _applicationContext.Users.Update(user);
            await _applicationContext.SaveChangesAsync();

            return ServiceResult.Success();
        }

        private async Task<RefreshToken> GenerateSaveRefreshToken(User user, CancellationToken cancellationToken)
        {
            var refreshToken = _tokenService.CreateJwtRefreshToken(_userService.IpAddress);
            refreshToken.UserId = user.Id;

            var countRefreshTokens = _applicationContext.RefreshTokens.Count(it => it.UserId == user.Id);

            if (countRefreshTokens >= 5) // если больше 5 токенов, то удаляем все и заносим новый в бд
            {
                var removeQueryable = _applicationContext.RefreshTokens.Where(it => it.UserId == user.Id);
                _applicationContext.RefreshTokens.RemoveRange(removeQueryable);
            }

            _applicationContext.RefreshTokens.Add(refreshToken);
            await _applicationContext.SaveChangesAsync(cancellationToken);

            return refreshToken;
        }

        private async Task<string> SendVerificationEmail(User user, string origin)
        {
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
            var route = "api/user/confirm-email/";
            var _enpointUri = new Uri(string.Concat($"{origin}/", route));
            var verificationUri = QueryHelpers.AddQueryString(_enpointUri.ToString(), "userId", user.Id.ToString());
            verificationUri = QueryHelpers.AddQueryString(verificationUri, "code", code);
            //Email Service Call Here
            return verificationUri;
        }
    }
}
