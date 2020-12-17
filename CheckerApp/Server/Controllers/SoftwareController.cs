using CheckerApp.Application.Softwares.Commands.CreateSoftware;
using CheckerApp.Application.Softwares.Commands.DeleteSoftware;
using CheckerApp.Application.Softwares.Commands.UpdateSoftware;
using CheckerApp.Application.Softwares.Queries.GetSoftware;
using CheckerApp.Application.Softwares.Queries.GetSoftwaresList;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CheckerApp.Server.Controllers
{
    public class SoftwareController : ApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetSoftwareList()
        {
            return Ok(await Mediator.Send(new GetSoftwaresListQuery()));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetSoftware(int id)
        {
            return Ok(await Mediator.Send(new GetSoftwareQuery { Id = id }));
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<int>> CreateSoftware([FromBody] CreateSoftwareCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [Authorize(Roles = "Admin, SuperUser")]
        [ProducesResponseType(201)]
        [HttpPut]
        public async Task<IActionResult> UpdateSoftware([FromBody] UpdateSoftwareCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteSoftware(int id)
        {
            await Mediator.Send(new DeleteSoftwareCommand { Id = id });

            return NoContent();
        }
    }
}
