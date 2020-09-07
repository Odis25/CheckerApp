using AutoMapper;
using System;
using System.Linq;
using System.Reflection;

namespace CheckerApp.Application.Common.Mappings
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            ApplyMappingsFromAssembly(Assembly.GetExecutingAssembly());
        }

        private void ApplyMappingsFromAssembly(Assembly assembly)
        {
            var types = assembly.GetExportedTypes()
                .Where(t => t.GetInterfaces().Any(i =>
                    i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapFrom<>)))
                .ToList();

            foreach (var type in types)
            {
                var instance = Activator.CreateInstance(type);
                var methodInfo = type.GetMethod("Mapping");
                methodInfo?.Invoke(instance, new object[] { this });
            }
        }

        //public MappingProfile()
        //{
        //    // Entities => ViewModels
        //    CreateMap<Contract, ContractDetailVm>();
        //    CreateMap<FlowMeterHardware, FlowMeterHardwareVm>();
        //    CreateMap<MeasurementHardware, MeasurementHardwareVm>();
        //    CreateMap<RS485Settings, RS485SettingsVm>();
        //    CreateMap<Hardware, HardwareDto>().IncludeAllDerived();

        //    // ViewModels => Entities
        //    //CreateMap<ContractVm, ContractVm>();
        //    CreateMap<FlowMeterHardwareVm, FlowMeterHardware>();
        //    CreateMap<MeasurementHardwareVm, MeasurementHardware>();
        //    CreateMap<RS485SettingsVm, RS485Settings>();
        //    CreateMap<HardwareDto, Hardware>().IncludeAllDerived();
        //}
    }
}
