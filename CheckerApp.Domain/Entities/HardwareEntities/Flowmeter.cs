namespace CheckerApp.Domain.Entities.HardwareEntities
{
    public class Flowmeter : Measurement
    {
        public double? Kfactor { get; set; }
        public virtual ModbusSettings Settings { get; set; }
    }
}
