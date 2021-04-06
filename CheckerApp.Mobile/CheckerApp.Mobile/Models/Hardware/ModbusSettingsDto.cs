using CheckerApp.Mobile.Common.Enums;

namespace CheckerApp.Mobile.Models.Hardware
{
    public class ModbusSettingsDto
    {
        public ModbusSettingsDto()
        {
            Address = 1;
            BoudRate = "9600";
            Parity = Parity.None;
            DataBits = "8";
            StopBit = "1";
        }
        public int Address { get; set; }
        public string BoudRate { get; set; }
        public Parity Parity { get; set; }
        public string DataBits { get; set; }
        public string StopBit { get; set; }
    }
}
