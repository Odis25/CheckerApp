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
        public async Task<ActionResult> GetAllContracts()
        {
            return Ok(await Mediator.Send(new GetContractsListQuery()));
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetContract(int id)
        {
            return Ok(await Mediator.Send(new GetContractDetailQuery { Id = id }));
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<int>> CreateContract([FromBody] CreateContractCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [Authorize]
        [HttpPut]
        public async Task<ActionResult> UpdateContract([FromBody] UpdateContractCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteContract(int id)
        {
            await Mediator.Send(new DeleteContractCommand { Id = id });

            return NoContent();
        }

    }
}
