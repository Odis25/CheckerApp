using CheckerApp.Infrastructure.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CheckerApp.WebUI.Pages
{
    public class LoginModel : PageModel
    {
        private readonly HttpClient _httpClient;

        public LoginModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IActionResult> OnGetAsync(string username, string password, string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            //try
            //{
            //    // Clear the existing external cookie
            //    await HttpContext.SignOutAsync("Cookies");
            //}
            //catch { }

            //var model = new UserCredentials
            //{
            //    UserName = username,
            //    Password = password
            //};

            //// Находим пользователя на сервере и получаем токен
            //var token = await GetTokenAsync(model);

            //// Авторизуем пользователя
            //await SignInUserAsync(token);

            var authProps = new AuthenticationProperties
            {
                IsPersistent = true,
                ExpiresUtc = DateTimeOffset.UtcNow.AddHours(15),
                RedirectUri = Url.Content("~/")
            };

            return Challenge(authProps, "oidc");
            try
            {
                await HttpContext.ChallengeAsync("oidc", new AuthenticationProperties{ RedirectUri = returnUrl });
            }
            catch (System.Exception ex)
            {

                throw;
            }

            return Redirect(returnUrl);
        }

        private async Task<string> GetTokenAsync(UserCredentials credentials)
        {
            var content = new StringContent(JsonSerializer.Serialize(credentials), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("https://localhost:5001/api/authentication", content);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }
        private IEnumerable<Claim> GetClaimsFromJwt(string token)
        {
            var claims = new List<Claim>();

            var payload = token.Split('.')[1];

            var jsonString = Base64UrlEncoder.Decode(payload);

            var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonString);

            keyValuePairs.TryGetValue(ClaimTypes.Role, out object roles);

            if (roles != null)
            {
                if (roles.ToString().Trim().StartsWith("["))
                {
                    var parsedRoles = JsonSerializer.Deserialize<string[]>(roles.ToString());

                    foreach (var parsedRole in parsedRoles)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, parsedRole));
                    }
                }
                else
                {
                    claims.Add(new Claim(ClaimTypes.Role, roles.ToString()));
                }

                keyValuePairs.Remove(ClaimTypes.Role);
            }

            claims.AddRange(keyValuePairs.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString())));

            return claims;
        }

        private async Task SignInUserAsync(string token)
        {
            // Получаем набор клаймов из токена
            var claims = GetClaimsFromJwt(token);

            // Собираем пользователя
            var user = new ClaimsPrincipal(new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme));

            // Авторизуем пользователя
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, user,
                new AuthenticationProperties
                {
                    IsPersistent = false
                });

            // Сохраняем токен в куки
            HttpContext.Response.Cookies.Append(".AspNetCore.Application.UserId", token, new CookieOptions
            {
                HttpOnly = true,
                Secure = true
            });
        }
    }
}
