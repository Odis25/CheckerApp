using CheckerApp.Application.Checks.Commands.CreateContractCheck;
using CheckerApp.Application.Checks.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;


namespace CheckerApp.Server.Controllers
{
    public class CheckController: ApiController
    {
        [HttpGet("{contractId:int}")]
        public async Task<ActionResult<ContractCheckDto>> Get(int contractId)
        {
            var result = await Mediator.Send(new GetCheckDocumentQuery { ContractId = contractId });
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] CreateCheckCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok();
        }
    }
}
