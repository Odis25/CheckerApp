using CheckerApp.Domain.Enums;

namespace CheckerApp.Application.Hardwares.Commands.CreateHardware
{
    public class ModbusSettingsDto
    {
        public int Id { get; set; }
        public uint Address { get; set; } // SlaveId
        public string BoudRate { get; set; } // 9600,19200, etc
        public Parity Parity { get; set; } // None, Odd, Even, Mark, Space
        public string DataBits { get; set; }
        public string StopBit { get; set; } // 1, 1.5, 2
    }
}