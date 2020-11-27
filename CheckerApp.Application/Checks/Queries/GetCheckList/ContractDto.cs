using AutoMapper;
using CheckerApp.Application.Common.Mappings;
using CheckerApp.Domain.Entities.ContractEntities;

namespace CheckerApp.Application.Checks.Queries.GetCheckList
{
    public class ContractDto : IMapFrom<Contract>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ContractNumber { get; set; }
        public string DomesticNumber { get; set; }
        public string ProjectNumber { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Contract, ContractDto>();
        }
    }
}