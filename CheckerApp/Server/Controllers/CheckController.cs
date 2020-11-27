using CheckerApp.Application.Checks.Queries.GetCheckResultFile;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using CheckerApp.Application.Checks.Queries.GetCheckList;
using CheckerApp.Application.Checks.Commands.SaveCheckResult;
using Microsoft.AspNetCore.Authorization;

namespace CheckerApp.Server.Controllers
{
    public class CheckController: ApiController
    {
        [Authorize(Roles = "Admin, SuperUser")]
        [HttpGet("{contractId:int}")]
        public async Task<IActionResult> GetCheckList(int contractId)
        {
            var result = await Mediator.Send(new GetCheckListQuery { ContractId = contractId });
            return Ok(result);
        }

        [Authorize(Roles = "Admin, SuperUser")]
        [HttpPost]
        public async Task<ActionResult<int>> SaveCheckResult([FromBody] SaveCheckResultCommand command)
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
