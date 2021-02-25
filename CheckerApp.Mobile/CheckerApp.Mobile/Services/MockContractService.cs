using CheckerApp.Mobile.Interfaces;
using CheckerApp.Mobile.Models;
using System;
using System.Threading.Tasks;

namespace CheckerApp.Mobile.Services
{
    public class MockContractService : IContractService
    {
        public async Task<ContractsListDto> GetContractsAsync()
        {
            var contracts = new ContractsListDto();

            contracts.Contracts.Add(new ContractDto
            {
                Id = 1,
                ContractNumber = "СПГ.123456",
                DomesticNumber = "12-2021",
                HasProtocol = true,
                ProjectNumber = "12-2021-111",
                Name = "Договор с очень-очень длинным названием которое не помещается на экран №1",
                LastChanges = DateTime.Now
            });

            contracts.Contracts.Add(new ContractDto
            {
                Id = 2,
                ContractNumber = "СПГ.4353454",
                DomesticNumber = "22-2021",
                HasProtocol = false,
                ProjectNumber = "22-2021-112",
                Name = "Договор с очень-очень длинным названием которое не помещается на экран №2",
                LastChanges = DateTime.Now
            });

            contracts.Contracts.Add(new ContractDto
            {
                Id = 1,
                ContractNumber = "СПГ.3463677",
                DomesticNumber = "32-2021",
                HasProtocol = true,
                ProjectNumber = "72-2021-5576",
                Name = "Договор с очень-очень длинным названием которое не помещается на экран №1",
                LastChanges = DateTime.Now
            });

            return contracts;
        }
    }
}
