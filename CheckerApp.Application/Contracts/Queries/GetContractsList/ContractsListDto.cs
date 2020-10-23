using System.Collections.Generic;

namespace CheckerApp.Application.Contracts.Queries.GetContractsList
{
    public class ContractsListDto
    {
        public IList<ContractDto> Contracts { get; set; }
    }
}