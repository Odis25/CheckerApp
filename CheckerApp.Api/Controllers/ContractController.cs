using CheckerApp.Application.Contracts.Commands.CreateContract;
using CheckerApp.Application.Contracts.Commands.UpdateContract;
using CheckerApp.Application.Contracts.Queries.GetContractDetail;
using CheckerApp.Application.Contracts.Queries.GetContractsList;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CheckerApp.Api.Controllers
{
    public class ContractController : ApiController
    {
        [HttpGet]
        public async Task<ActionResult> GetAllContracts()
        {
            return Ok(await Mediator.Send(new GetContractsListQuery()));
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ContractDetailVm>> GetContract(int id)
        {
            return Ok(await Mediator.Send(new GetContractDetailQuery { Id = id }));
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateContract([FromBody] CreateContractCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPut]
        public async Task<ActionResult> UpdateContract([FromBody] UpdateContractCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

    }
}
