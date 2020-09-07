namespace CheckerApp.Domain.Entities.HardwareEntities
{
    public class FlowMeterHardware : MeasurementHardware
    {
        public double? Kfactor { get; set; }
        public RS485Settings Settings { get; set; }
    }
}
