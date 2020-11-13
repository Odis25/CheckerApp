using CheckerApp.Domain.Enums;

namespace CheckerApp.Application.Hardwares.Commands.CreateHardware
{
    public class ModbusSettingsDto
    {
        public int Id { get; set; }
        public uint Address { get; set; }
        public string BoudRate { get; set; }
        public Parity Parity { get; set; }
        public string DataBits { get; set; }
        public string StopBit { get; set; }
    }
}