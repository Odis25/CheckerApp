using MediatR;

namespace CheckerApp.Application.Checks.Queries.GetCheckResultFile
{
    public class GetCheckResultFileQuery : IRequest<CheckResultFileDto>
    {
        public int ContractId { get; set; }
    }
}
