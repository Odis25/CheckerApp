using MediatR;

namespace CheckerApp.Application.Hardwares.Queries
{
    public class GetHardwareDetailQuery : IRequest<HardwareVm>
    {
        public int Id { get; set; }       
    }
}
