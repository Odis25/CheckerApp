
namespace CheckerApp.Domain.Entities.HardwareEntities
{
    public class ModbusSettings
    {
        public uint Address { get; set; } // SlaveId
        public string BoudRate { get; set; } // 9600, 19200, etc
        public string Parity { get; set; } // None, Odd, Even, Mark, Space
        public string DataBits { get; set; }
        public string StopBit { get; set; } // 1, 1.5, 2
    }
}
