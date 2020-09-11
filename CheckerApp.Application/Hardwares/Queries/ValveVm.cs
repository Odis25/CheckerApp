using AutoMapper;
using CheckerApp.Domain.Entities.HardwareEntities;
using CheckerApp.Domain.Enums;
using System;

namespace CheckerApp.Application.Hardwares.Queries
{
    public class ValveVm : HardwareVm
    {
        public string DeviceType { get; set; }
        public string DeviceModel { get; set; }
        public SignalType SignalType { get; set; }
        public virtual ModbusSettingsDto ModbusSettings { get; set; }

        public new void Mapping(Profile profile)
        {
            profile.CreateMap<Valve, ValveVm>()
                .ForMember(dest => dest.ModbusSettings, opt => opt.MapFrom(src => src.Settings));
        }
    }
}
