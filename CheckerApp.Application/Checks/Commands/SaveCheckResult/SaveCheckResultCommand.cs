using CheckerApp.Application.Checks.Queries.GetCheckList;
using MediatR;

namespace CheckerApp.Application.Checks.Commands.SaveCheckResult
{
    public class SaveCheckResultCommand : IRequest
    {
        public CheckListDto CheckResult { get; set; }
    }
}
