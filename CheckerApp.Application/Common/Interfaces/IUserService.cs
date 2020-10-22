using CheckerApp.Domain.Entities.Identity;
using System.Threading.Tasks;

namespace CheckerApp.Application.Common.Interfaces
{
    public interface IUserService
    {
        Task<ApplicationUser> GetUserAsync(string username, string password);
    }
}
