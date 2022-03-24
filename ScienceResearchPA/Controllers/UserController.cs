using App.Common.Interfaces;
using App.Users.DTOs;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
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

        public UserController(IAccountService accountService, ICurrentUserService userService)
        {
            _accountService = accountService;
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<ActionResult> RegisterPost(RegisterRequest registerRequest, CancellationToken cancellationToken)
        {
            return Ok(await _accountService.RegisterAsync(registerRequest, cancellationToken));
        }

        [HttpPost("login")]
        public async Task<ActionResult> LoginPost(AuthenticationRequest authenticationRequest, CancellationToken cancellationToken)
        {
            return Ok(await _accountService.AuthenticateAsync(authenticationRequest, _userService, cancellationToken));
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
    }
}
