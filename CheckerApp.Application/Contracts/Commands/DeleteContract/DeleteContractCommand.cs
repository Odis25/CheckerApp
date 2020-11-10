using MediatR;

namespace CheckerApp.Application.Contracts.Commands.DeleteContract
{
    public class DeleteContractCommand : IRequest
    {
        public int Id { get; set; }
    }
}
