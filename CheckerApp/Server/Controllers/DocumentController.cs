using CheckerApp.Application.Documents.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;


namespace CheckerApp.Server.Controllers
{
    public class DocumentController: ApiController
    {
        [HttpGet("{contractId:int}")]
        public async Task<ActionResult<ContractCheckStatusVm>> Get(int contractId)
        {
            var result = await Mediator.Send(new GetCheckDocumentQuery { ContractId = contractId });
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] ContractCheckStatusVm checkStatus)
        {
            return Ok();
        }
    }
}
