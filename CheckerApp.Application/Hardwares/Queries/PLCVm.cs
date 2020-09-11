using AutoMapper;
using CheckerApp.Domain.Entities.HardwareEntities;

namespace CheckerApp.Application.Hardwares.Queries
{
    public class PLCVm : ControllerVm
    {
        public new void Mapping(Profile profile)
        {
            profile.CreateMap<PLC, PLCVm>();
        }
    }
}
