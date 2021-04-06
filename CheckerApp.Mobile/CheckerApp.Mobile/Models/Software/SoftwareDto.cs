using CheckerApp.Mobile.Common.Enums;

namespace CheckerApp.Mobile.Models.Software
{
    public class SoftwareDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Version { get; set; }
        public SoftwareType SoftwareType { get; set; }
    }
}
