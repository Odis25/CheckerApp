using AutoMapper;
using CheckerApp.Application.Common.Mappings;
using CheckerApp.Domain.Entities.HardwareEntities;
using CheckerApp.Domain.Enums;
using System;

namespace CheckerApp.Application.Hardwares.Queries
{
    public class ModbusSettingsDto : IMapFrom<ModbusSettings>
    {
        public int Id { get; set; }
        public uint Address { get; set; } 
        public string BoudRate { get; set; } 
        public Parity Parity { get; set; } 
        public string DataBits { get; set; }
        public string StopBit { get; set; } 

        public void Mapping(Profile profile)
        {
            profile.CreateMap<string, Parity>().ConvertUsing(s => Enum.Parse<Parity>(s));
            profile.CreateMap<ModbusSettings, ModbusSettingsDto>();
        }
    }
}
