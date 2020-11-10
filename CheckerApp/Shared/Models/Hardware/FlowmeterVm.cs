using CheckerApp.Shared.Enums;

namespace CheckerApp.Shared.Models.Hardware
{
    public class FlowmeterVm : MeasurementVm
    {
        public FlowmeterVm()
        {
            HardwareType = HardwareType.Flowmeter;
        }
        public double? Kfactor { get; set; }
        public ModbusSettingsVm ModbusSettings { get; set; }
    }
}
