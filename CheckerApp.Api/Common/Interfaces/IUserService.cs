using CheckerApp.Domain.Common;
using CheckerApp.Infrastructure.Models;
using System.Threading.Tasks;

namespace CheckerApp.WebApi.Common.Interfaces
{
    public interface IUserService
    {
        Task<ApplicationUser> GetUserAsync(UserCredentials model);
        Task<UserToken> GetTokenAsync(ApplicationUser user);
    }
}
