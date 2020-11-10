using MediatR;

namespace CheckerApp.Application.Hardwares.Commands.DeleteHardware
{
    public class DeleteHardwareCommand : IRequest
    {
        public int Id { get; set; }
    }
}
