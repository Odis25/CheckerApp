using CheckerApp.Application.Checks.Queries.GetCheckResult;
using MediatR;

namespace CheckerApp.Application.Checks.Commands.UpsertCheckResult
{
    public class UpsertCheckResultCommand : IRequest<int>
    {
        public CheckListDto CheckResult { get; set; }
    }
}
