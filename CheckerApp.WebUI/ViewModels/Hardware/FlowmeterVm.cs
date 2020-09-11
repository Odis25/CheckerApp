
namespace CheckerApp.WebUI.ViewModels.Hardware
{
    public class FlowMeterVm : MeasurementVm
    {
        public double? Kfactor { get; set; }
        public ModbusSettingsVm Settings { get; set; }
    }
}
