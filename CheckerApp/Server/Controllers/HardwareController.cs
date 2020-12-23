using CheckerApp.Application.Hardwares.Commands.CreateHardware;
using CheckerApp.Application.Hardwares.Commands.DeleteHardware;
using CheckerApp.Application.Hardwares.Commands.ImportFromFile;
using CheckerApp.Application.Hardwares.Commands.UpdateHardware;
using CheckerApp.Application.Hardwares.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CheckerApp.Server.Controllers
{
    public class HardwareController : ApiController
    {
        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetHardware(int id)
        {
            return Ok(await Mediator.Send(new GetHardwareDetailQuery { Id = id }));
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<int>> CreateHardware([FromBody] CreateHardwareCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteHardware(int id)
        {
            await Mediator.Send(new DeleteHardwareCommand { Id = id });

            return NoContent();
        }

        [Authorize(Roles = "Admin, SuperUser")]
        [ProducesResponseType(201)]
        [HttpPut]
        public async Task<IActionResult> UpdateHardware([FromBody] UpdateHardwareCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        [HttpPost("import/{id}")]
        public async Task<IActionResult> ImportFromFile(string id, [FromBody] FileModel fileModel)
        {
            await Mediator.Send(new ImportFromFileCommand { ContractId = int.Parse(id), FileContent = fileModel.Content });

            return Ok();
        } 
    }
}
