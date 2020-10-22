using MediatR;

namespace CheckerApp.Application.Checks.Queries
{
    public class GetCheckDocumentQuery : IRequest<ContractCheckVm>
    {
        public int ContractId { get; set; }
    }
}
