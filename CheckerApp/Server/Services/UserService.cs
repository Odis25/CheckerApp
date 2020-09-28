using CheckerApp.Domain.Common;
using CheckerApp.Infrastructure.Models;
using CheckerApp.Server.Common.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CheckerApp.Server.Services
{
    public class UserService : IUserService
    {
        private const string DisplayNameAttribute = "DisplayName";
        private const string GivenNameAttribute = "GivenName";
        private const string SnAttribute = "Sn";
        private const string SAMAccountNameAttribute = "SAMAccountName";

        private readonly UserManager<ApplicationUser> _userManager;

        public UserService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<ApplicationUser> GetUserAsync(string username, string password)
        {
            using (var context = new PrincipalContext(ContextType.Domain, "INCOMSYSTEM.ru"))
            {
                // Проверка логина и пароля
                if (context.ValidateCredentials(username, password))
                {
                    var user = await _userManager.FindByNameAsync(username);

                    if (user == null)
                    {
                        // Поиск пользователя в ActiveDirectory
                        using (var entry = new DirectoryEntry("LDAP://incomsystem.ru", "INCOMSYSTEM\\" + username, password))
                        {
                            using (var searcher = new DirectorySearcher(entry))
                            {
                                // Критерий поиска
                                searcher.Filter = $"SAMAccountName={username}";

                                // Получаемые свойства
                                searcher.PropertiesToLoad.Add(SAMAccountNameAttribute);
                                searcher.PropertiesToLoad.Add(DisplayNameAttribute);
                                searcher.PropertiesToLoad.Add(GivenNameAttribute);
                                searcher.PropertiesToLoad.Add(SnAttribute);

                                var result = searcher.FindOne();

                                if (result != null)
                                {
                                    var accountName = result.Properties[SAMAccountNameAttribute][0].ToString();
                                    var displayName = result.Properties[DisplayNameAttribute][0].ToString();

                                    user = new ApplicationUser
                                    {
                                        UserName = accountName,
                                        //NormalizedUserName = accountName.ToLower(),
                                        //ConcurrencyStamp = Guid.NewGuid().ToString(),
                                        FullName = displayName
                                    };

                                    await _userManager.CreateAsync(user);
                                    var res = await _userManager.AddToRoleAsync(user, "User");
                                }
                            }
                        }
                    }
                    return user;
                }
                return null;
            }
        }

        public async Task<UserToken> GetTokenAsync(ApplicationUser user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, user.NormalizedUserName),
                new Claim("user_full_name", user.FullName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var roles = await _userManager.GetRolesAsync(user);

            var roleClaims = roles.Select(role => new Claim(ClaimTypes.Role, role));

            claims.AddRange(roleClaims);

            var expiration = DateTime.UtcNow.AddYears(1);

            JwtSecurityToken token = new JwtSecurityToken(
                    issuer: null,
                    audience: null,
                    claims: claims,
                    expires: expiration);

            return new UserToken
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = expiration
            };
        }
    }
}

