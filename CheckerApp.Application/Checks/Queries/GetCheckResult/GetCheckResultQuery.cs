using MediatR;

namespace CheckerApp.Application.Checks.Queries.GetCheckResult
{
    public class GetCheckResultQuery : IRequest<CheckResultDto>
    {
        public int ContractId { get; set; }
    }
}
