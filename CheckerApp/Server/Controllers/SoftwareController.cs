using CheckerApp.Application.Softwares.Commands.CreateSoftware;
using CheckerApp.Application.Softwares.Commands.DeleteSoftware;
using CheckerApp.Application.Softwares.Queries.GetSoftwaresList;
using CheckerApp.Shared.Models.Commands;
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

        [HttpPost]
        public async Task<ActionResult<int>> CreateSoftware([FromBody] CreateSoftwareCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteSoftware(int id)
        {
            await Mediator.Send(new DeleteSoftwareCommand { Id = id });

            return NoContent();
        }
    }
}
