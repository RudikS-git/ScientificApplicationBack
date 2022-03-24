using App.Common.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace ScienceResearchPA.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        public string UserId { get; set; }
        public string IpAddress { get; set; }

        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            UserId = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
            IpAddress = GenerateIPAddress(httpContextAccessor.HttpContext.Request);
        }

        private string GenerateIPAddress(HttpRequest httpRequest)
        {
            if (httpRequest.Headers.ContainsKey("X-Forwarded-For"))
                return httpRequest.Headers["X-Forwarded-For"];
            else
                return httpRequest.HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
        }
    }

}
