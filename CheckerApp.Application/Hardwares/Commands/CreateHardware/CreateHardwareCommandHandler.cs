using CheckerApp.Application.Common.Interfaces;
using CheckerApp.Domain.Entities.HardwareEntities;
using CheckerApp.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CheckerApp.Application.Hardwares.Commands.CreateHardware
{
    public class CreateHardwareCommandHandler : IRequestHandler<CreateHardwareCommand, int>
    {
        private readonly IAppDbContext _context;

        public CreateHardwareCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateHardwareCommand request, CancellationToken cancellationToken)
        {
            var contract = await _context.Contracts.FirstOrDefaultAsync(c => c.Id == request.ContractId);

            if (contract == null)
            {
                throw new NullReferenceException("Договор с таким Id не найден.");
            }

            Hardware entity;

            switch (request.HardwareType)
            {
                case HardwareType.Cabinet:
                    entity = new Cabinet
                    {
                        Position = request.Position,
                        SerialNumber = request.SerialNumber,
                        Constructed = (DateTime)request.Constructed,
                        ConstructedBy = request.ConstructedBy
                    };
                    break;
                case HardwareType.FlowComputer:
                    entity = new FlowComputer
                    {
                        Position = request.Position,
                        SerialNumber = request.SerialNumber,
                        DeviceModel = request.DeviceModel,
                        IP = request.IPAddress,
                        AssemblyVersion = request.AssemblyVersion,
                        CRC32 = request.CRC32,
                        LastConfigDate = request.LastConfigDate
                    };
                    break;
                case HardwareType.Flowmeter:
                    entity = new Flowmeter
                    {
                        Position = request.Position,
                        SerialNumber = request.SerialNumber,
                        DeviceModel = request.DeviceModel,
                        DeviceType = request.DeviceType,
                        MinValue = request.MinValue,
                        MaxValue = request.MaxValue,
                        EU = request.EU,
                        Kfactor = request.KFactor,
                        SignalType = request.SignalType,
                        Settings = new ModbusSettings
                        {
                            Address = request.ModbusSettings.Address,
                            BoudRate = request.ModbusSettings.BoudRate,
                            DataBits = request.ModbusSettings.DataBits,
                            Parity = Enum.GetName(typeof(Parity), request.ModbusSettings.Parity),
                            StopBit = request.ModbusSettings.StopBit
                        }
                    };
                    break;
                case HardwareType.Network:
                    entity = new NetworkHardware
                    {
                        Position = request.Position,
                        SerialNumber = request.SerialNumber,
                        DeviceType = request.DeviceType,
                        DeviceModel = request.DeviceModel,
                        Mask = request.Mask
                    };
                    foreach (var item in request.NetworkDevices)
                    {
                        ((NetworkHardware)entity).NetworkDevices.Add(new NetworkDevice 
                        { 
                            IP = item.IP, 
                            MacAddress = item.MacAddress, 
                            Name = item.Name 
                        });
                    }
                    break;
                case HardwareType.PLC:
                    entity = new PLC
                    {
                        Position = request.Position,
                        SerialNumber = request.SerialNumber,
                        DeviceModel = request.DeviceModel,
                        IP = request.IPAddress,
                        AssemblyVersion = request.AssemblyVersion
                    };
                    break;
                case HardwareType.Pressure:
                    entity = new Pressure
                    {
                        Position = request.Position,
                        SerialNumber = request.SerialNumber,
                        DeviceModel = request.DeviceModel,
                        DeviceType = request.DeviceType,
                        MinValue = request.MinValue,
                        MaxValue = request.MaxValue,
                        EU = request.EU,
                        SignalType = request.SignalType
                    };
                    break;
                case HardwareType.Temperature:
                    entity = new Temperature
                    {
                        Position = request.Position,
                        SerialNumber = request.SerialNumber,
                        DeviceModel = request.DeviceModel,
                        DeviceType = request.DeviceType,
                        MinValue = request.MinValue,
                        MaxValue = request.MaxValue,
                        EU = request.EU,
                        SignalType = request.SignalType
                    };
                    break;
                case HardwareType.DiffPressure:
                    entity = new DiffPressure
                    {
                        Position = request.Position,
                        SerialNumber = request.SerialNumber,
                        DeviceModel = request.DeviceModel,
                        DeviceType = request.DeviceType,
                        MinValue = request.MinValue,
                        MaxValue = request.MaxValue,
                        EU = request.EU,
                        SignalType = request.SignalType
                    };
                    break;
                case HardwareType.Valve:
                    entity = new Valve
                    {
                        Position = request.Position,
                        SerialNumber = request.SerialNumber,
                        DeviceType = request.DeviceType,
                        DeviceModel = request.DeviceModel,
                        SignalType = request.SignalType,
                        Settings = new ModbusSettings
                        {
                            Address = request.ModbusSettings.Address,
                            BoudRate = request.ModbusSettings.BoudRate,
                            DataBits = request.ModbusSettings.DataBits,
                            Parity = Enum.GetName(typeof(Parity), request.ModbusSettings.Parity),
                            StopBit = request.ModbusSettings.StopBit
                        }
                    };
                    break;
                case HardwareType.ARM:
                    entity = new ARM
                    {
                        Position = request.Position,
                        Name = request.ArmName,
                        SerialNumber = request.SerialNumber,
                        Monitor = request.Monitor,
                        MonitorSN = request.MonitorSN,
                        Keyboard = request.Keyboard,
                        KeyboardSN = request.KeyboardSN,
                        Mouse = request.Mouse,
                        MouseSN = request.MouseSN,
                        OS = request.OS,
                        ProductKeyOS = request.ProductKeyOS,
                        HasRAID = request.HasRAID
                    };
                    foreach (var item in request.NetworkAdapters)
                    {
                        ((ARM)entity).NetworkAdapters.Add(new NetworkAdapter
                        {
                            IP = item.IP,
                            MacAddress = item.MacAddress
                        });
                    }
                    break;
                default:
                    entity = null;
                    break;
            }

            entity.HardwareType = request.HardwareType;

            contract.HardwareList.Add(entity);
            contract.HasProtocol = false;
            _context.Update(contract);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
