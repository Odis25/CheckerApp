using AutoMapper;
using CheckerApp.Domain.Entities.HardwareEntities;
using CheckerApp.Domain.Enums;

namespace CheckerApp.Application.Contracts.Queries.GetContractDetail
{
    public class HardwareTypeResolver : IValueResolver<Hardware, HardwareDto, HardwareType>
    {
        public HardwareType Resolve(Hardware source, HardwareDto destination, HardwareType destMember, ResolutionContext context)
        {
            return source switch
            {
                Cabinet e => HardwareType.Cabinet,
                ARM e => HardwareType.ARM,
                Flowmeter e => HardwareType.Flowmeter,
                Pressure e => HardwareType.Pressure,
                DiffPressure e => HardwareType.DiffPressure,
                Temperature e => HardwareType.Temperature,
                GasAnalyzer e => HardwareType.GasAnalyzer,
                FlowComputer e => HardwareType.FlowComputer,
                PLC e => HardwareType.PLC,
                NetworkHardware e => HardwareType.Network,
                Valve e => HardwareType.Valve,
                InformPanel e => HardwareType.InformPanel,
                _ => HardwareType.Valve,
            };
        }
    }
}