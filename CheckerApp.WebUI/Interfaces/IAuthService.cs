using CheckerApp.WebUI.ViewModels.Login;
using System.Threading.Tasks;

namespace CheckerApp.WebUI.Interfaces
{
    public interface IAuthService
    {
        Task Login(UserCredentials model);
        Task Logout();
    }
}
