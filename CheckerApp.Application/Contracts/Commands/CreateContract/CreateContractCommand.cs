using MediatR;

namespace CheckerApp.Application.Contracts.Commands.CreateContract
{
    public class CreateContractCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string ContractNumber { get; set; }
        public string DomesticNumber { get; set; }
        public string ProjectNumber { get; set; }
    }
}
