using MediatR;

namespace CheckerApp.Application.Hardwares.Queries
{
    public class GetHardwareDetailQuery : IRequest<HardwareDto>
    {
        public int Id { get; set; }       
    }
}
