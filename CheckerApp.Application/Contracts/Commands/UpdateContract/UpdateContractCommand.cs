using MediatR;

namespace CheckerApp.Application.Contracts.Commands.UpdateContract
{
    public class UpdateContractCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ContractNumber { get; set; }
        public string DomesticNumber { get; set; }
        public string ProjectNumber { get; set; }
    }
}
