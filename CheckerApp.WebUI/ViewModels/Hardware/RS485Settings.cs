
using CheckerApp.WebUI.Enums;

namespace CheckerApp.WebUI.ViewModels.Hardware
{
    public class RS485Settings
    {
        public RS485Settings()
        {
            Address = "1";
            BoudRate = "9600";
            Parity = Parity.None;
            DataBits = "8";
            StopBit = "1";
        }
        public string Address { get; set; } // SlaveId
        public string BoudRate { get; set; } // 9600,19200, etc
        public Parity Parity { get; set; } // None, Odd, Even, Mark, Space
        public string DataBits { get; set; }
        public string StopBit { get; set; } // 1, 1.5, 2
    }
}
