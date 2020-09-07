using MediatR;

namespace CheckerApp.Application.Contracts.Queries.GetContractsList
{
    public class GetContractsListQuery : IRequest<ContractsListVm>
    {
    }
}
