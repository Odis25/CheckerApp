using CheckerApp.Shared.Enums;
using System;

namespace CheckerApp.Shared.Hardware
{
    public class CreateHardwareVm
    {
        public CreateHardwareVm()
        {
            ModbusSettings = new ModbusSettingsVm();
        }
        public HardwareType HardwareType { get; set; }
        public int ContractId { get; set; }
        public string Position { get; set; }
        public string SerialNumber { get; set; }
        public string DeviceType { get; set; }
        public string DeviceModel { get; set; }
        public double MinValue { get; set; }
        public double MaxValue { get; set; }
        public string EU { get; set; }
        public string IPAddress { get; set; }
        public string ConstructedBy { get; set; }
        public DateTime Constructed { get; set; }
        public SignalType SignalType { get; set; }
        public double? KFactor { get; set; }
        public string AssemblyVersion { get; set; }
        public string CRC32 { get; set; }
        public ulong? LastConfigDate { get; set; }
        public ModbusSettingsVm ModbusSettings { get; set; }
    }
}
