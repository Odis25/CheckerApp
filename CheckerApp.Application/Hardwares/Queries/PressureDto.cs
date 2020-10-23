using AutoMapper;
using CheckerApp.Domain.Entities.HardwareEntities;

namespace CheckerApp.Application.Hardwares.Queries
{
    public class PressureDto : MeasurementDto
    {
        public new void Mapping(Profile profile)
        {
            profile.CreateMap<Pressure, PressureDto>();
        }
    }
}
