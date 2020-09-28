using CheckerApp.Domain.Common;
using CheckerApp.Server.Common.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace CheckerApp.Server.Pages
{
    public class LoginModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserService _userService;

        [BindProperty]
        [Required(ErrorMessage = "Ёто поле об€зательно дл€ заполнени€")]
        public string Name { get; set; }
        [BindProperty]
        [Required(ErrorMessage = "Ёто поле об€зательно дл€ заполнени€")]
        public string Password { get; set; }
        [BindProperty]
        public string ReturnUrl { get; set; }

        public LoginModel(
            SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager,
            IUserService userService)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _userService = userService;
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl ?? Url.Content("~/");
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            if (ModelState.IsValid)
            {
                var user = await _userService.GetUserAsync(Name, Password);

                if (user != null)
                {
                    await _signInManager.SignInAsync(user, false);
                    return LocalRedirect(ReturnUrl);
                }

                ModelState.AddModelError("", "Ќекорректный логин или пароль");
            }

            return Page();
        }
    }
}
