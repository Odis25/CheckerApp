using AutoMapper;
using CheckerApp.Application.Common.Mappings;
using CheckerApp.Domain.Entities.Documents;
using System.Collections.Generic;

namespace CheckerApp.Application.Checks.Queries.GetCheckResult
{
    public class CheckResultDto : IMapFrom<CheckResult>
    {
        public CheckResultDto()
        {
            HardwareChecks = new HashSet<HardwareCheckDto>();
        }

        public int Id { get; set; }
        public ContractDto Contract { get; set; }
        public IEnumerable<HardwareCheckDto> HardwareChecks { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CheckResult, CheckResultDto>();
        } 
    }
}
