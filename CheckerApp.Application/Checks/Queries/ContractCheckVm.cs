﻿using CheckerApp.Application.Contracts.Queries.GetContractsList;
using System.Collections.Generic;

namespace CheckerApp.Application.Checks.Queries
{
    public class ContractCheckVm
    {
        public ContractCheckVm()
        {
            HardwareChecks = new HashSet<HardwareCheckDto>();
        }
        public ContractDto Contract { get; set; }
        public ICollection<HardwareCheckDto> HardwareChecks { get; set; }
    }
}
