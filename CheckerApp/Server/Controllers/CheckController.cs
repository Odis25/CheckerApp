using CheckerApp.Application.Checks.Queries.GetCheckResultFile;
using CheckerApp.Application.Checks.Queries.GetCheckResult;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using CheckerApp.Application.Checks.Commands.UpsertCheckResult;

namespace CheckerApp.Server.Controllers
{
    public class CheckController: ApiController
    {
        [HttpGet("{contractId:int}")]
        public async Task<IActionResult> GetCheckResult(int contractId)
        {
            var result = await Mediator.Send(new GetCheckResultQuery { ContractId = contractId });
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateCheckResult([FromBody] UpsertCheckResultCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("download/{contractId:int}")]
        public async Task<FileResult> Download(int contractId)
        {
            var result = await Mediator.Send(new GetCheckResultFileQuery { ContractId = contractId });
            return File(result.Content, result.ContentType, result.FileName);
        }
    }
}
