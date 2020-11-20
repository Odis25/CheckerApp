using CheckerApp.Application.Hardwares.Commands.CreateHardware;
using CheckerApp.Application.Hardwares.Commands.DeleteHardware;
using CheckerApp.Application.Hardwares.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CheckerApp.Server.Controllers
{
    public class HardwareController : ApiController
    {
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<int>> CreateHardware([FromBody] CreateHardwareCommand command)
        {
            return Ok(await Mediator.Send(command));
        }


        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetHardware(int id)
        {
            return Ok(await Mediator.Send(new GetHardwareDetailQuery { Id = id }));
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteHardware(int id)
        {
            await Mediator.Send(new DeleteHardwareCommand { Id = id });

            return NoContent();
        }
    }
}
