namespace CheckerApp.Shared.Models.Hardware
{
    public class FlowmeterVm : MeasurementVm
    {
        public double? Kfactor { get; set; }
        public ModbusSettingsVm ModbusSettings { get; set; }
    }
}
