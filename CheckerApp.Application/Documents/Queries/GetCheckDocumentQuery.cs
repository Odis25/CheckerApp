using MediatR;

namespace CheckerApp.Application.Documents.Queries
{
    public class GetCheckDocumentQuery : IRequest<ContractCheckStatusVm>
    {
        public int ContractId { get; set; }
    }
}
