using AutoMapper;
using CheckerApp.Domain.Entities.HardwareEntities;
using System;

namespace CheckerApp.Application.Hardwares.Queries
{
    public class CabinetVm: HardwareVm
    {
        public DateTime Constructed { get; set; }
        public string ConstructedBy { get; set; }

        public new void Mapping(Profile profile)
        {
            profile.CreateMap<Cabinet, CabinetVm>();
        }
    }
}
