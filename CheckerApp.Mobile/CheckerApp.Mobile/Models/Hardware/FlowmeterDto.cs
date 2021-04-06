using CheckerApp.Mobile.Common.Enums;

namespace CheckerApp.Mobile.Models.Hardware
{
    public class FlowmeterDto : MeasurementDto
    {
        public FlowmeterDto()
        {
            HardwareType = HardwareType.Flowmeter;
        }
        public double? Kfactor { get; set; }
        public ModbusSettingsDto ModbusSettings { get; set; }
    }
}
