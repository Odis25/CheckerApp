using AutoMapper;
using CheckerApp.Domain.Entities.HardwareEntities;

namespace CheckerApp.Application.Hardwares.Queries
{
    public class FlowmeterDto : MeasurementDto
    {
        public double? Kfactor { get; set; }
        public ModbusSettingsDto ModbusSettings { get; set; }

        public new void Mapping(Profile profile)
        {
            profile.CreateMap<Flowmeter, FlowmeterDto>()
                .ForMember(dest => dest.ModbusSettings, opt => opt.MapFrom(src => src.Settings)); ;
        }
    }
}
