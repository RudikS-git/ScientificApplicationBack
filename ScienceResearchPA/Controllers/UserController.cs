using App.Common.Interfaces;
using App.Users.DTOs;
using App.Users.Queries;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ScienceResearchPA.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : BaseApiController
    {
        private readonly IAccountService _accountService;
        private readonly ICurrentUserService _userService;
        private readonly IConfiguration _configuration;

        public UserController(IAccountService accountService, ICurrentUserService userService, IConfiguration configuration)
        {
            _accountService = accountService;
            _userService = userService;
            _configuration = configuration;
        } 

        [Authorize]
        [HttpGet("me")]
        public async Task<IActionResult> MeGet(CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetUserInfoQuery(_userService.UserId), cancellationToken));
        }

        [HttpPost("register")]
        public async Task<ActionResult> RegisterPost(RegisterRequest registerRequest, CancellationToken cancellationToken)
        {
            return Ok(await _accountService.RegisterAsync(registerRequest, cancellationToken));
        }

        [HttpPost("login")]
        public async Task<ActionResult> LoginPost(AuthenticationRequest authenticationRequest, CancellationToken cancellationToken)
        {
            var result = await _accountService.AuthenticateAsync(authenticationRequest, cancellationToken);

            if(result.Error == null)
            {
                setRefreshTokenInCookie(result.Data.RefreshToken);
            }
            
            return Ok(result);
        }

        [HttpGet("confirm-email")]
        public async Task<ActionResult> ConfrimEmailGet([FromQuery] string userId, [FromQuery] string code, CancellationToken cancellationToken)
        {
            // TODO: add userId and code to constructor ConfirmEmailRequest
            return Ok(await _accountService.ConfirmEmail(new ConfirmEmailRequest(), cancellationToken));
        }

        [HttpPost("forgot-password")]
        public async Task<ActionResult> ForgotPasswordPost(ForgotPasswordRequest forgotPasswordRequest , CancellationToken cancellationToken)
        {
            return Ok(await _accountService.ForgotPassword(forgotPasswordRequest, cancellationToken));
        }

        [HttpPost("reset-password")]
        public async Task<ActionResult> ResetPasswordPost(ResetPasswordRequest resetPasswordRequest, CancellationToken cancellationToken)
        {
            return Ok(await _accountService.ResetPassword(resetPasswordRequest, cancellationToken));
        }

        [HttpPost("refresh-token")]
        public async Task<ActionResult> RefreshToken(CancellationToken cancellationToken)
        {
            var result = await _accountService.RefreshToken(Request.Cookies[_configuration["JWTSettings:RefreshToken:CookieName"]], cancellationToken);
            
            if(result.Error == null)
            {
                setRefreshTokenInCookie(result.Data.RefreshToken);
            }

            return Ok(result);
        }

        [HttpPut("revoke-refresh-token")]
        public async Task<ActionResult> RevokeRefreshToken(CancellationToken cancellationToken)
        {
            var result = await _accountService.RevokeRefreshToken(Request.Cookies[_configuration["JWTSettings:RefreshToken:CookieName"]], cancellationToken);
            deleteRefreshTokenInCookie();

            return Ok(result);
        }

        private void setRefreshTokenInCookie(string token)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = DateTime.UtcNow.AddMinutes(int.Parse(_configuration["JWTSettings:RefreshToken:LifeTime"])),
                Path = "api/user",
                SameSite = SameSiteMode.Strict
            };

            Response.Cookies.Append(_configuration["JWTSettings:RefreshToken:CookieName"], token, cookieOptions);
        }

        private void deleteRefreshTokenInCookie()
        {
            Response.Cookies.Delete(_configuration["JWTSettings:RefreshToken:CookieName"]);
        }

    }
}
