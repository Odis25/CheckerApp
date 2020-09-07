using CheckerApp.Domain.Enums;

namespace CheckerApp.Application.Hardwares.DTOs
{
    public class RS485SettingsVm
    {
        public uint Address { get; set; } // SlaveId
        public string BoudRate { get; set; } // 9600,19200, etc
        public Parity Parity { get; set; } // None, Odd, Even, Mark, Space
        public byte DataBits { get; set; }
        public string StopBit { get; set; } // 1, 1.5, 2
    }
}
