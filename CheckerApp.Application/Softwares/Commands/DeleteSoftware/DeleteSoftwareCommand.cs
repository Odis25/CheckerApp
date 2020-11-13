using MediatR;

namespace CheckerApp.Application.Softwares.Commands.DeleteSoftware
{
    public class DeleteSoftwareCommand : IRequest
    {
        public int Id { get; set; }
    }
}
