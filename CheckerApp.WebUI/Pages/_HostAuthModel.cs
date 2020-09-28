using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheckerApp.WebUI.Pages
{
    public class _HostAuthModel: PageModel
    {
        public IActionResult OnGetLogin()
        {
            var authProps = new AuthenticationProperties
            {
                IsPersistent = true,
                ExpiresUtc = DateTimeOffset.UtcNow.AddHours(15),
                RedirectUri = Url.Content("~/")
            };
            return Challenge(authProps, "oidc");
        }

        public async Task OnGetLogout()
        {
            var authProps = new AuthenticationProperties
            {
                RedirectUri = Url.Content("~/")
            };
            await HttpContext.SignOutAsync("Cookies");
            await HttpContext.SignOutAsync("oidc", authProps);
        }
    }
}
