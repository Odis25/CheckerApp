using AutoMapper;
using CheckerApp.Domain.Entities.HardwareEntities;

namespace CheckerApp.Application.Hardwares.Queries
{
    public class FlowmeterVm : MeasurementVm
    {
        public double? Kfactor { get; set; }
        public ModbusSettingsDto Settings { get; set; }

        public new void Mapping(Profile profile)
        {
            profile.CreateMap<Flowmeter, FlowmeterVm>();
        }
    }
}
