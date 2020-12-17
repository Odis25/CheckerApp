using CheckerApp.Application.Contracts.Commands.CreateContract;
using CheckerApp.Application.Contracts.Commands.DeleteContract;
using CheckerApp.Application.Contracts.Commands.UpdateContract;
using CheckerApp.Application.Contracts.Queries.GetContractDetail;
using CheckerApp.Application.Contracts.Queries.GetContractsList;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CheckerApp.Server.Controllers
{
    public class ContractController : ApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetContractsList()
        {
            return Ok(await Mediator.Send(new GetContractsListQuery()));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetContract(int id)
        {
            return Ok(await Mediator.Send(new GetContractDetailQuery { Id = id }));
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<int>> CreateContract([FromBody] CreateContractCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [Authorize(Roles = "Admin, SuperUser")]
        [ProducesResponseType(201)]
        [HttpPut]
        public async Task<IActionResult> UpdateContract([FromBody] UpdateContractCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteContract(int id)
        {
            await Mediator.Send(new DeleteContractCommand { Id = id });

            return NoContent();
        }

    }
}
