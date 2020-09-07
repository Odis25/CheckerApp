
namespace CheckerApp.WebUI.ViewModels.Hardware
{
    public class FlowMeterVm : MeasurementVm
    {
        public double? Kfactor { get; set; }
        public RS485Settings Settings { get; set; }
    }
}
