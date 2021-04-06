using CheckerApp.Mobile.Models.Hardware;
using CheckerApp.Mobile.Models.Software;
using System;
using System.Collections.Generic;

namespace CheckerApp.Mobile.Models
{
    public class ContractDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ContractNumber { get; set; }
        public string DomesticNumber { get; set; }
        public string ProjectNumber { get; set; }
        public bool HasProtocol { get; set; }

        public IEnumerable<HardwareDto> HardwareList { get; set; }
        public IEnumerable<SoftwareDto> SoftwareList { get; set; }

        public string CreatedBy { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime Created { get; set; }
        public DateTime? LastModified { get; set; }
    }
}
