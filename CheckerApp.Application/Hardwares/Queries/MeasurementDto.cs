using AutoMapper;
using CheckerApp.Domain.Entities.HardwareEntities;
using CheckerApp.Domain.Enums;

namespace CheckerApp.Application.Hardwares.Queries
{
    public class MeasurementDto : HardwareDto
    {
        public string DeviceType { get; set; }
        public string DeviceModel { get; set; }
        public double MinValue { get; set; }
        public double MaxValue { get; set; }
        public string EU { get; set; }
        public SignalType SignalType { get; set; }

        public new void Mapping(Profile profile)
        {
            profile.CreateMap<Measurement, MeasurementDto>();
        }
    }
}
