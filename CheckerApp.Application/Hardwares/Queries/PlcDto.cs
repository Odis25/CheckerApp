using AutoMapper;
using CheckerApp.Domain.Entities.HardwareEntities;

namespace CheckerApp.Application.Hardwares.Queries
{
    public class PlcDto : ControllerDto
    {
        public new void Mapping(Profile profile)
        {
            profile.CreateMap<PLC, PlcDto>();
        }
    }
}
