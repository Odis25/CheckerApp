using CheckerApp.Application.Common.Interfaces;
using CheckerApp.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using System.DirectoryServices.AccountManagement;
using System.Threading.Tasks;

namespace CheckerApp.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<ApplicationUser> GetUserAsync(string username, string password)
        {
            using (var context = new PrincipalContext(ContextType.Domain, "INCOMSYSTEM.ru", username, password))
            {
                ApplicationUser user = null;
                if (context.ValidateCredentials(username, password))
                {
                    user = await _userManager.FindByNameAsync(username);

                    if (user == null)
                    {
                        var userPrincipal = UserPrincipal.FindByIdentity(context, IdentityType.SamAccountName, username);

                        var nameArray = userPrincipal.DisplayName.Split(' ');

                        user = new ApplicationUser
                        {
                            UserName = username,
                            FullName = $"{nameArray[1]} {nameArray[0]}"
                        };

                        await _userManager.CreateAsync(user);

                        if (user.UserName.Equals("budanovav", System.StringComparison.OrdinalIgnoreCase))
                        {
                            await _userManager.AddToRoleAsync(user, "Admin");
                        }
                        else
                        {
                            await _userManager.AddToRoleAsync(user, "User");
                        }
                    }
                }
                return user;
            }
        }
    }
}

