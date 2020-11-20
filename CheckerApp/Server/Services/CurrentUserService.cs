using CheckerApp.Application.Common.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace CheckerApp.Server.Services
{
    public class CurrentUserService : ICurrentUserService
    {

        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            UserId = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
            UserName = httpContextAccessor.HttpContext?.User?.FindFirstValue("full_name");
            IsAuthenticated = UserId != null;
        }
        public string UserId { get; }
        public string UserName { get; }
        public bool IsAuthenticated { get; }
    }
}
