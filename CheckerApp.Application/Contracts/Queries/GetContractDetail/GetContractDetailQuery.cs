using MediatR;

namespace CheckerApp.Application.Contracts.Queries.GetContractDetail
{
    public class GetContractDetailQuery : IRequest<ContractDetailDto>
    {
        public int Id { get; set; }
    }
}
