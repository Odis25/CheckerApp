using CheckerApp.Application.Common.Interfaces;
using CheckerApp.Application.Hardwares.Queries;
using CheckerApp.Domain.Entities.HardwareEntities;
using CheckerApp.Domain.Enums;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CheckerApp.Application.Hardwares.Commands.UpdateHardware
{
    public class UpdateHardwareCommandHandler : IRequestHandler<UpdateHardwareCommand>
    {
        private readonly IAppDbContext _context;

        public UpdateHardwareCommandHandler(IAppDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(UpdateHardwareCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Hardwares.FindAsync(request.Hardware.Id);
            var hardware = request.Hardware;

            switch (hardware.HardwareType)
            {
                case HardwareType.Cabinet:
                    ((Cabinet)entity).Position = ((CabinetDto)hardware).Position;
                    ((Cabinet)entity).SerialNumber = ((CabinetDto)hardware).SerialNumber;
                    ((Cabinet)entity).Constructed = ((CabinetDto)hardware).Constructed;
                    ((Cabinet)entity).ConstructedBy = ((CabinetDto)hardware).ConstructedBy;
                    break;

                case HardwareType.FlowComputer:
                    ((FlowComputer)entity).Position = ((FlowComputerDto)hardware).Position;
                    ((FlowComputer)entity).SerialNumber = ((FlowComputerDto)hardware).SerialNumber;
                    ((FlowComputer)entity).DeviceModel = ((FlowComputerDto)hardware).DeviceModel;
                    ((FlowComputer)entity).AssemblyVersion = ((FlowComputerDto)hardware).AssemblyVersion;
                    ((FlowComputer)entity).CRC32 = ((FlowComputerDto)hardware).CRC32;
                    ((FlowComputer)entity).IP = ((FlowComputerDto)hardware).IP;
                    ((FlowComputer)entity).LastConfigDate = ((FlowComputerDto)hardware).LastConfigDate;
                    break;

                case HardwareType.Flowmeter:
                    ((Flowmeter)entity).Position = ((FlowmeterDto)hardware).Position;
                    ((Flowmeter)entity).SerialNumber = ((FlowmeterDto)hardware).SerialNumber;
                    ((Flowmeter)entity).DeviceType = ((FlowmeterDto)hardware).DeviceType;
                    ((Flowmeter)entity).DeviceModel = ((FlowmeterDto)hardware).DeviceModel;
                    ((Flowmeter)entity).MinValue = ((FlowmeterDto)hardware).MinValue;
                    ((Flowmeter)entity).MaxValue = ((FlowmeterDto)hardware).MaxValue;
                    ((Flowmeter)entity).EU = ((FlowmeterDto)hardware).EU;
                    ((Flowmeter)entity).Kfactor = ((FlowmeterDto)hardware).Kfactor;
                    ((Flowmeter)entity).SignalType = ((FlowmeterDto)hardware).SignalType;
                    ((Flowmeter)entity).Settings.Address = ((FlowmeterDto)hardware).ModbusSettings.Address;
                    ((Flowmeter)entity).Settings.BoudRate = ((FlowmeterDto)hardware).ModbusSettings.BoudRate;
                    ((Flowmeter)entity).Settings.Parity = ((FlowmeterDto)hardware).ModbusSettings.Parity.ToString();
                    ((Flowmeter)entity).Settings.DataBits = ((FlowmeterDto)hardware).ModbusSettings.DataBits;
                    ((Flowmeter)entity).Settings.StopBit = ((FlowmeterDto)hardware).ModbusSettings.StopBit;
                    break;

                case HardwareType.Network:
                    ((NetworkHardware)entity).Position = ((NetworkHardwareDto)hardware).Position;
                    ((NetworkHardware)entity).SerialNumber = ((NetworkHardwareDto)hardware).SerialNumber;
                    ((NetworkHardware)entity).DeviceType = ((NetworkHardwareDto)hardware).DeviceType;
                    ((NetworkHardware)entity).DeviceModel = ((NetworkHardwareDto)hardware).DeviceModel;
                    ((NetworkHardware)entity).Mask = ((NetworkHardwareDto)hardware).Mask;

                    ((NetworkHardware)entity).NetworkDevices.Clear();

                    foreach (var item in ((NetworkHardwareDto)hardware).NetworkDevices)
                    {
                        var device = new NetworkDevice
                        {
                            Name = item.Name,
                            IP = item.IP,
                            MacAddress = item.MacAddress
                        };

                        ((NetworkHardware)entity).NetworkDevices.Add(device);
                    };
                    break;

                case HardwareType.PLC:
                    ((PLC)entity).Position = ((PlcDto)hardware).Position;
                    ((PLC)entity).SerialNumber = ((PlcDto)hardware).SerialNumber;
                    ((PLC)entity).DeviceModel = ((PlcDto)hardware).DeviceModel;
                    ((PLC)entity).AssemblyVersion = ((PlcDto)hardware).AssemblyVersion;
                    ((PLC)entity).IP = ((PlcDto)hardware).IP;
                    break;

                case HardwareType.Pressure:
                    ((Pressure)entity).Position = ((PressureDto)hardware).Position;
                    ((Pressure)entity).SerialNumber = ((PressureDto)hardware).SerialNumber;
                    ((Pressure)entity).DeviceType = ((PressureDto)hardware).DeviceType;
                    ((Pressure)entity).DeviceModel = ((PressureDto)hardware).DeviceModel;
                    ((Pressure)entity).MinValue = ((PressureDto)hardware).MinValue;
                    ((Pressure)entity).MaxValue = ((PressureDto)hardware).MaxValue;
                    ((Pressure)entity).EU = ((PressureDto)hardware).EU;
                    ((Pressure)entity).SignalType = ((PressureDto)hardware).SignalType;
                    break;

                case HardwareType.DiffPressure:
                    ((DiffPressure)entity).Position = ((DiffPressureDto)hardware).Position;
                    ((DiffPressure)entity).SerialNumber = ((DiffPressureDto)hardware).SerialNumber;
                    ((DiffPressure)entity).DeviceType = ((DiffPressureDto)hardware).DeviceType;
                    ((DiffPressure)entity).DeviceModel = ((DiffPressureDto)hardware).DeviceModel;
                    ((DiffPressure)entity).MinValue = ((DiffPressureDto)hardware).MinValue;
                    ((DiffPressure)entity).MaxValue = ((DiffPressureDto)hardware).MaxValue;
                    ((DiffPressure)entity).EU = ((DiffPressureDto)hardware).EU;
                    ((DiffPressure)entity).SignalType = ((DiffPressureDto)hardware).SignalType;
                    break;

                case HardwareType.Temperature:
                    ((Temperature)entity).Position = ((TemperatureDto)hardware).Position;
                    ((Temperature)entity).SerialNumber = ((TemperatureDto)hardware).SerialNumber;
                    ((Temperature)entity).DeviceType = ((TemperatureDto)hardware).DeviceType;
                    ((Temperature)entity).DeviceModel = ((TemperatureDto)hardware).DeviceModel;
                    ((Temperature)entity).MinValue = ((TemperatureDto)hardware).MinValue;
                    ((Temperature)entity).MaxValue = ((TemperatureDto)hardware).MaxValue;
                    ((Temperature)entity).EU = ((TemperatureDto)hardware).EU;
                    ((Temperature)entity).SignalType = ((TemperatureDto)hardware).SignalType;
                    break;

                case HardwareType.GasAnalyzer:
                    ((GasAnalyzer)entity).Position = ((GasAnalyzerDto)hardware).Position;
                    ((GasAnalyzer)entity).SerialNumber = ((GasAnalyzerDto)hardware).SerialNumber;
                    ((GasAnalyzer)entity).DeviceType = ((GasAnalyzerDto)hardware).DeviceType;
                    ((GasAnalyzer)entity).DeviceModel = ((GasAnalyzerDto)hardware).DeviceModel;
                    ((GasAnalyzer)entity).MinValue = ((GasAnalyzerDto)hardware).MinValue;
                    ((GasAnalyzer)entity).MaxValue = ((GasAnalyzerDto)hardware).MaxValue;
                    ((GasAnalyzer)entity).EU = ((GasAnalyzerDto)hardware).EU;
                    ((GasAnalyzer)entity).SignalType = ((GasAnalyzerDto)hardware).SignalType;
                    break;

                case HardwareType.APC:
                    ((APC)entity).Position = ((ApcDto)hardware).Position;
                    ((APC)entity).SerialNumber = ((ApcDto)hardware).SerialNumber;
                    ((APC)entity).DeviceType = ((ApcDto)hardware).DeviceType;
                    ((APC)entity).DeviceModel = ((ApcDto)hardware).DeviceModel;
                    break;

                case HardwareType.FireSensor:
                    ((FireSensor)entity).Position = ((FireSensorDto)hardware).Position;
                    ((FireSensor)entity).SerialNumber = ((FireSensorDto)hardware).SerialNumber;
                    ((FireSensor)entity).DeviceType = ((FireSensorDto)hardware).DeviceType;
                    ((FireSensor)entity).DeviceModel = ((FireSensorDto)hardware).DeviceModel;
                    break;
                case HardwareType.FireModule:
                    ((FireModule)entity).Position = ((FireModuleDto)hardware).Position;
                    ((FireModule)entity).SerialNumber = ((FireModuleDto)hardware).SerialNumber;
                    ((FireModule)entity).DeviceType = ((FireModuleDto)hardware).DeviceType;
                    break;

                case HardwareType.InformPanel:
                    ((InformPanel)entity).Position = ((InformPanelDto)hardware).Position;
                    ((InformPanel)entity).SerialNumber = ((InformPanelDto)hardware).SerialNumber;
                    ((InformPanel)entity).DeviceType = ((InformPanelDto)hardware).DeviceType;
                    ((InformPanel)entity).DeviceModel = ((InformPanelDto)hardware).DeviceModel;
                    ((InformPanel)entity).PanelType = ((InformPanelDto)hardware).PanelType;
                    break;

                case HardwareType.Valve:
                    ((Valve)entity).Position = ((ValveDto)hardware).Position;
                    ((Valve)entity).SerialNumber = ((ValveDto)hardware).SerialNumber;
                    ((Valve)entity).DeviceType = ((ValveDto)hardware).DeviceType;
                    ((Valve)entity).DeviceModel = ((ValveDto)hardware).DeviceModel;
                    ((Valve)entity).SignalType = ((ValveDto)hardware).SignalType;
                    ((Valve)entity).Settings.Address = ((ValveDto)hardware).ModbusSettings.Address;
                    ((Valve)entity).Settings.BoudRate = ((ValveDto)hardware).ModbusSettings.BoudRate;
                    ((Valve)entity).Settings.Parity = ((ValveDto)hardware).ModbusSettings.Parity.ToString();
                    ((Valve)entity).Settings.DataBits = ((ValveDto)hardware).ModbusSettings.DataBits;
                    ((Valve)entity).Settings.StopBit = ((ValveDto)hardware).ModbusSettings.StopBit;
                    break;

                case HardwareType.ARM:
                    ((ARM)entity).Position = ((ArmDto)hardware).Position;
                    ((ARM)entity).Name = ((ArmDto)hardware).Name;
                    ((ARM)entity).SerialNumber = ((ArmDto)hardware).SerialNumber;
                    ((ARM)entity).Monitor = ((ArmDto)hardware).Monitor;
                    ((ARM)entity).MonitorSN = ((ArmDto)hardware).MonitorSN;
                    ((ARM)entity).Keyboard = ((ArmDto)hardware).Keyboard;
                    ((ARM)entity).KeyboardSN = ((ArmDto)hardware).KeyboardSN;
                    ((ARM)entity).Mouse = ((ArmDto)hardware).Mouse;
                    ((ARM)entity).MouseSN = ((ArmDto)hardware).MouseSN;
                    ((ARM)entity).OS = ((ArmDto)hardware).OS;
                    ((ARM)entity).ProductKeyOS = ((ArmDto)hardware).ProductKeyOS;
                    ((ARM)entity).HasRAID = ((ArmDto)hardware).HasRAID;

                    ((ARM)entity).NetworkAdapters.Clear();

                    foreach (var item in ((ArmDto)hardware).NetworkAdapters)
                    {
                        var device = new NetworkAdapter
                        {
                            IP = item.IP,
                            MacAddress = item.MacAddress
                        };

                        ((ARM)entity).NetworkAdapters.Add(device);
                    };
                    break;
            }

            try
            {
                await _context.SaveChangesAsync(cancellationToken);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }

            return Unit.Value;
        }
    }
}
