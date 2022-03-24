using App.Common.Models;
using App.Users.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace App.Common.Interfaces
{
    public interface IAccountService
    {
        Task<ServiceResult> AuthenticateAsync(AuthenticationRequest authenticationRequest, ICurrentUserService userService, CancellationToken cancellationToken);
        Task<ServiceResult> RegisterAsync(RegisterRequest registerRequest, CancellationToken cancellationToken);
        Task<ServiceResult> ConfirmEmail(ConfirmEmailRequest confirmEmailRequest, CancellationToken cancellationToken);
        Task<ServiceResult> ForgotPassword(ForgotPasswordRequest forgotPasswordRequest, CancellationToken cancellationToken);
        Task<ServiceResult> ResetPassword(ResetPasswordRequest resetPasswordRequest, CancellationToken cancellationToken);
    }
}
