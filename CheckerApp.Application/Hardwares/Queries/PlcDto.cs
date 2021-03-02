using AutoMapper;
using CheckerApp.Domain.Entities.HardwareEntities;

namespace CheckerApp.Application.Hardwares.Queries
{
    public class PlcDto : ControllerDto
    {
        public PlcDto()
        {
            HardwareType = Domain.Enums.HardwareType.PLC;
        }
        public new void Mapping(Profile profile)
        {
            profile.CreateMap<PLC, PlcDto>();
        }
    }
}
