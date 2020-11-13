using AutoMapper;
using CheckerApp.Application.Common.Mappings;
using CheckerApp.Application.Softwares.Queries.GetSoftwaresList;
using CheckerApp.Domain.Entities.CheckEntities;
using System.Collections.Generic;

namespace CheckerApp.Application.Checks.Queries.GetCheckResultFile
{
    public class SoftwareCheckDto : IMapFrom<SoftwareCheck>
    {
        public SoftwareCheckDto()
        {
            CheckParameters = new HashSet<CheckParameterDto>();
        }
        public SoftwareDto Software { get; set; }
        public ICollection<CheckParameterDto> CheckParameters { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<SoftwareCheck, SoftwareCheckDto>();
        }
    }

}
