using CheckerApp.Application.Checks.Queries;
using MediatR;

namespace CheckerApp.Application.Checks.Commands.CreateContractCheck
{
    public class CreateCheckCommand : IRequest<int>
    {
        public ContractCheckDto ContractCheck { get; set; }
    }
}
