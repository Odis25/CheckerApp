using System.Collections.Generic;

namespace CheckerApp.Domain.Entities.HardwareEntities
{
    public class ARM : Hardware
    {
        public ARM()
        {
            NetworkAdapters = new HashSet<NetworkAdapter>();
        }
        public string Name { get; set; }
        public string Monitor { get; set; }
        public string MonitorSN { get; set; }
        public string Keyboard { get; set; }
        public string KeyboardSN { get; set; }
        public string Mouse { get; set; }
        public string MouseSN { get; set; }
        public bool HasRAID { get; set; }

        public string OS { get; set; }
        public string ProductKeyOS { get; set; }

        public virtual ICollection<NetworkAdapter> NetworkAdapters { get; set; }
    }

    public class NetworkAdapter
    {
        public string IP { get; set; }
        public string MacAddress { get; set; }
    }
}
