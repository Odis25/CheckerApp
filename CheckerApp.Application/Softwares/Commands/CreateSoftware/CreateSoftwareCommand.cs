using CheckerApp.Domain.Enums;
using MediatR;

namespace CheckerApp.Application.Softwares.Commands.CreateSoftware
{
    public class CreateSoftwareCommand : IRequest<int>
    {
        public int ContractId { get; set; }
        public string Name { get; set; }
        public string Version { get; set; }
        public SoftwareType SoftwareType { get; set; }
    }
}
