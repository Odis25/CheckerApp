using System.Collections.Generic;

namespace CheckerApp.Domain.Entities.CheckEntities
{
    public class HardwareCheck
    {
        public int Id { get; set; }
        public int HardwareId { get; set; }
        public virtual IEnumerable<CheckParameter> CheckParameters { get; set; }

    }
}
