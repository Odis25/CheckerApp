using CheckerApp.Application.Hardwares.Queries;
using MediatR;

namespace CheckerApp.Application.Hardwares.Commands.UpdateHardware
{
    public class UpdateHardwareCommand : IRequest
    {
        public HardwareDto Hardware { get; set; }
    }
}
