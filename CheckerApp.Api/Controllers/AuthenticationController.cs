using CheckerApp.Application.Authentication.Commands;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CheckerApp.WebApi.Controllers
{
    public class AuthenticationController : ApiController
    {
        public async Task<ActionResult<string>> PostAsync(CreateTokenCommand credentials)
        {
            string token = await Mediator.Send(credentials);

            return Ok(token);
        }
    }
}
