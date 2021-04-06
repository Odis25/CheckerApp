using CheckerApp.Mobile.Common.Enums;

namespace CheckerApp.Mobile.Models.Hardware 
{ 
    public class PlcDto : ControllerDto
    {
        public PlcDto()
        {
            HardwareType = HardwareType.PLC;
        }
    }
}
