using AutoMapper;
using CheckerApp.Domain.Entities.HardwareEntities;

namespace CheckerApp.Application.Hardwares.Queries
{
    public class PressureVm : MeasurementVm
    {
        public new void Mapping(Profile profile)
        {
            profile.CreateMap<Pressure, PressureVm>();
        }
    }
}
