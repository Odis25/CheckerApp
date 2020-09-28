using CheckerApp.WebUI.Interfaces;
using CheckerApp.WebUI.ViewModels.Login;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CheckerApp.WebUI.Services
{
    public class AuthService : AuthenticationStateProvider, IAuthService
    {
        private readonly HttpClient _httpClient;
        private readonly HttpContextAccessor _httpContextAccessor;

        public AuthService(HttpClient httpClient, HttpContextAccessor httpContextAccessor)
        {
            _httpClient = httpClient;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task Login(UserCredentials model)
        {
            // Находим пользователя на сервере и получаем токен
            var token = await GetTokenAsync(model);

            var state = await SignInUserAsync(token);

            NotifyAuthenticationStateChanged(Task.FromResult(state));
        }

        public Task Logout()
        {
            throw new NotImplementedException();
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

        public override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var state = new AuthenticationState(_httpContextAccessor.HttpContext.User);
            return Task.FromResult(state);
        }

        private async Task<AuthenticationState>SignInUserAsync(string token)
        {
            // Получаем набор клаймов из токена
            var claims = GetClaimsFromJwt(token);

            // Собираем пользователя
            var user = new ClaimsPrincipal(new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme));

            // Авторизуем пользователя
            await _httpContextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, user,
                new AuthenticationProperties
                {
                    IsPersistent = false
                });

            // Сохраняем токен в куки
            _httpContextAccessor.HttpContext.Response.Cookies.Append(".AspNetCore.Application.UserId", token, new CookieOptions
            {
                HttpOnly = true,
                Secure = true
            });

            return new AuthenticationState(user);
        }
    }
}
