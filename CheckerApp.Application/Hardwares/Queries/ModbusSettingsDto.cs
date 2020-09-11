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
        public uint Address { get; set; } // SlaveId
        public string BoudRate { get; set; } // 9600,19200, etc
        public Parity Parity { get; set; } // None, Odd, Even, Mark, Space
        public string DataBits { get; set; }
        public string StopBit { get; set; } // 1, 1.5, 2

        public void Mapping(Profile profile)
        {
            profile.CreateMap<string, Parity>().ConvertUsing(s => Enum.Parse<Parity>(s));
            profile.CreateMap<ModbusSettings, ModbusSettingsDto>();
        }
    }
}
