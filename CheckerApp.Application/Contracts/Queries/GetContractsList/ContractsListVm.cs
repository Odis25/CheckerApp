using System.Collections.Generic;

namespace CheckerApp.Application.Contracts.Queries.GetContractsList
{
    public class ContractsListVm
    {
        public IList<ContractDto> Contracts { get; set; }
    }
}