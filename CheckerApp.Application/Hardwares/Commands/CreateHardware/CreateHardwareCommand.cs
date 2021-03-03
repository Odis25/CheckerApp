using CheckerApp.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;

namespace CheckerApp.Application.Hardwares.Commands.CreateHardware
{
    public class CreateHardwareCommand : IRequest<int>
    {
        public HardwareType HardwareType { get; set; }
        public SignalType SignalType { get; set; }
        public InformPanelType PanelType { get; set; }
        public int ContractId { get; set; }
        public string SerialNumber { get; set; }
        public string Position { get; set; }
        public string DeviceType { get; set; }
        public string DeviceModel { get; set; }
        public double MinValue { get; set; }
        public double MaxValue { get; set; }
        public string EU { get; set; }
        public string IPAddress { get; set; }
        public string ConstructedBy { get; set; }
        public DateTime? Constructed { get; set; }
        public double? KFactor { get; set; }
        public string AssemblyVersion { get; set; }
        public string CRC32 { get; set; }
        public ulong? LastConfigDate { get; set; }
        public string Mask { get; set; }
        public ICollection<NetworkDeviceDto> NetworkDevices { get; set; }
        public ModbusSettingsDto ModbusSettings { get; set; }

        public string ArmName { get; set; }
        public string Monitor { get; set; }
        public string MonitorSN { get; set; }
        public string Keyboard { get; set; }
        public string KeyboardSN { get; set; }
        public string Mouse { get; set; }
        public string MouseSN { get; set; }
        public bool HasRAID { get; set; }
        public string OS { get; set; }
        public string ProductKeyOS { get; set; }
        public ICollection<NetworkAdapterDto> NetworkAdapters { get; set; }
    }
}
