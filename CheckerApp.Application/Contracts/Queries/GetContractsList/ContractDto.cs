using AutoMapper;
using CheckerApp.Application.Common.Mappings;
using CheckerApp.Domain.Entities.ContractEntities;
using System.Collections.Generic;

namespace CheckerApp.Application.Contracts.Queries.GetContractsList
{
    public class ContractDto : IMapFrom<Contract>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ContractNumber { get; set; }
        public string DomesticNumber { get; set; }
        public bool HasProtocol { get; set; }
        public IEnumerable<HardwareDto> HardwareList { get; set; }
        public IEnumerable<SoftwareDto> SoftwareList { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Contract, ContractDto>();
        }
    }
}