using CheckerApp.Application.Common.Interfaces;
using CheckerApp.Domain.Entities.Identity; // подумать как избавиться от привязки к доменному уровню
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
        private readonly IUserService _userService;

        [BindProperty]
        [Required(ErrorMessage = "Это поле обязательно для заполнения")]
        public string Name { get; set; }
        [BindProperty]
        [Required(ErrorMessage = "Это поле обязательно для заполнения")]
        public string Password { get; set; }
        [BindProperty]
        public string ReturnUrl { get; set; }

        public LoginModel(
            SignInManager<ApplicationUser> signInManager,
            IUserService userService)
        {
            _signInManager = signInManager;
            _userService = userService;
        }

        public void OnGet(string returnUrl = null)
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

                ModelState.AddModelError("", "Некорректный логин или пароль");
            }

            return Page();
        }
    }
}
