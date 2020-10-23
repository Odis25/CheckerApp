using AutoMapper;
using CheckerApp.Domain.Entities.HardwareEntities;

namespace CheckerApp.Application.Hardwares.Queries
{
    public class TemperatureDto : MeasurementDto
    {
        public new void Mapping(Profile profile)
        {
            profile.CreateMap<Temperature, TemperatureDto>();
        }
    }
}
