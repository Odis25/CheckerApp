using CheckerApp.Domain.Common;
using CheckerApp.Infrastructure.Models;
using CheckerApp.WebApi.Common.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CheckerApp.WebApi.Controllers
{
    public class AuthController : ApiController
    {
        private readonly IUserService _userService;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AuthController(IUserService userService, SignInManager<ApplicationUser> signInManager)
        {
            _userService = userService;
            _signInManager = signInManager;
        }

        [HttpGet]
        public async Task<IActionResult> Login()
        {
            return Ok("Hello");
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] UserCredentials model)
        {
            var userV = User;
            var user = await _userService.GetUserAsync(model);

            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Неправильный логин или пароль");
                return BadRequest(ModelState);
            }

            await _signInManager.SignInAsync(user, false);

            //var token = await _userService.GetTokenAsync(user);
            return Redirect(model.ReturnUrl);
            return Ok(model);
        }
    }
}
