using MediatR;

namespace CheckerApp.Application.Softwares.Commands.UpdateSoftware
{
    public class UpdateSoftwareCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Version { get; set; }
    }
}
