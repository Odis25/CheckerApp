using CheckerApp.Application.Users.Commands.UpdateUsers;
using CheckerApp.Application.Users.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CheckerApp.Server.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UsersController : ApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetUsersList()
        {
            return Ok(await Mediator.Send(new GetUsersListQuery()));
        }

        [ProducesResponseType(201)]
        [HttpPut]
        public async Task<IActionResult> UpdateUsersList([FromBody] UpdateUsersCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
