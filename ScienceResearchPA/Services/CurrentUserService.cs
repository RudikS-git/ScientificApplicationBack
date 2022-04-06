using App.Common.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace ScienceResearchPA.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        public int UserId { get; set; }
        public string IpAddress { get; set; }

        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            UserId = GetUserId(httpContextAccessor);
            IpAddress = GenerateIPAddress(httpContextAccessor.HttpContext.Request);
        }

        private string GenerateIPAddress(HttpRequest httpRequest)
        {
            if (httpRequest.Headers.ContainsKey("X-Forwarded-For"))
                return httpRequest.Headers["X-Forwarded-For"];
            else
                return httpRequest.HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
        }

        private int GetUserId(IHttpContextAccessor httpContextAccessor)
        {
            int.TryParse(httpContextAccessor.HttpContext?.User?.FindFirstValue("id"), out int userId);
            return userId;
        }
    }

}
