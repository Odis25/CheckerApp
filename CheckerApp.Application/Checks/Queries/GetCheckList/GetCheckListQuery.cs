using MediatR;

namespace CheckerApp.Application.Checks.Queries.GetCheckList
{
    public class GetCheckListQuery : IRequest<CheckListDto>
    {
        public int ContractId { get; set; }
    }
}
