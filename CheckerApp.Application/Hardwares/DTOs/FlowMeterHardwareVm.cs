namespace CheckerApp.Application.Hardwares.DTOs
{
    public class FlowMeterHardwareVm : MeasurementHardwareVm
    {
        public double? Kfactor { get; set; }
        public RS485SettingsVm Settings { get; set; }
    }
}
