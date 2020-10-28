using MediatR;

namespace CheckerApp.Application.Checks.Queries.GetCheckResult
{
    public class GetCheckResultQuery : IRequest<CheckListDto>
    {
        public int ContractId { get; set; }
    }
}
