using AutoMapper;
using CheckerApp.Application.Common.Mappings;
using CheckerApp.Domain.Entities.Documents;
using System.Collections.Generic;

namespace CheckerApp.Application.Checks.Queries.GetCheckResultFile
{
    public class CheckResultDto : IMapFrom<CheckResult>
    {
        public int Id { get; set; }
        public ContractDto Contract { get; set; }
        public ICollection<HardwareCheckDto> HardwareChecks { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CheckResult, CheckResultDto>();
        }
    }
}
