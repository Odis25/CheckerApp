using System.Collections.Generic;

namespace CheckerApp.Mobile.Models
{
    public class ContractsListDto
    {
        public ContractsListDto()
        {
            Contracts = new List<ContractDto>();
        }
        public IList<ContractDto> Contracts { get; set; }
    }
}
