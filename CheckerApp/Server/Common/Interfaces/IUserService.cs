using CheckerApp.Domain.Common;
using CheckerApp.Infrastructure.Models;
using System.Threading.Tasks;

namespace CheckerApp.Server.Common.Interfaces
{
    public interface IUserService
    {
        Task<ApplicationUser> GetUserAsync(string username, string password);
        Task<UserToken> GetTokenAsync(ApplicationUser user);
    }
}
