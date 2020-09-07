using MediatR;

namespace CheckerApp.Application.Contracts.Queries.GetContractDetail
{
    public class GetContractDetailQuery : IRequest<ContractDetailVm>
    {
        public int Id { get; set; }
    }
}
