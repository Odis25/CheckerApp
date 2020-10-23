using MediatR;

namespace CheckerApp.Application.Checks.Queries
{
    public class GetCheckDocumentQuery : IRequest<ContractCheckDto>
    {
        public int ContractId { get; set; }
    }
}
