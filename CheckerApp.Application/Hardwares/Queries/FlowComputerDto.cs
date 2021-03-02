using AutoMapper;
using CheckerApp.Domain.Entities.HardwareEntities;

namespace CheckerApp.Application.Hardwares.Queries
{
    public class FlowComputerDto : ControllerDto
    {
        public FlowComputerDto()
        {
            HardwareType = Domain.Enums.HardwareType.FlowComputer;
        }
        public string CRC32 { get; set; }
        public ulong? LastConfigDate { get; set; }
        public new void Mapping(Profile profile)
        {
            profile.CreateMap<FlowComputer, FlowComputerDto>();
        }
    }
}
