using CheckerApp.Application.Hardwares.Commands.CreateHardware;
using CheckerApp.Application.Hardwares.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CheckerApp.Server.Controllers
{
    public class HardwareController : ApiController
    {
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
    }
}
