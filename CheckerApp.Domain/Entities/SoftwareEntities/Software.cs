using CheckerApp.Domain.Entities.CheckEntities;
using CheckerApp.Domain.Enums;

namespace CheckerApp.Domain.Entities.SoftwareEntities
{
    public class Software
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Version { get; set; }
        public SoftwareType SoftwareType { get; set; }

        public virtual SoftwareCheck CheckResult { get; set; }
    }
}
