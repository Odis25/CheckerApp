using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CheckerApp.WebApi.Controllers
{
    public class AccountController : ApiController
    {

        [HttpGet]
        public async Task<IActionResult> Login(string returnUrl)
        {
            return Ok();
        }
    }
}
