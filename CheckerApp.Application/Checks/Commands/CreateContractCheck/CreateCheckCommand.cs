using CheckerApp.Application.Checks.Queries.GetCheckResult;
using MediatR;

namespace CheckerApp.Application.Checks.Commands.CreateContractCheck
{
    public class CreateCheckCommand : IRequest<int>
    {
        public CheckResultDto ContractCheck { get; set; }
    }
}
