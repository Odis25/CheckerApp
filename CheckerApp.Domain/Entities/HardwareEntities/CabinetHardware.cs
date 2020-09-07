using System;

namespace CheckerApp.Domain.Entities.HardwareEntities
{
    public class CabinetHardware: Hardware
    {
        public DateTime Constructed { get; set; }
        public string ConstructedBy { get; set; }
    }
}
