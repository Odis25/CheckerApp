using AutoMapper;
using CheckerApp.Application.Common.Mappings;
using CheckerApp.Domain.Entities.CheckEntities;
using System;

namespace CheckerApp.Application.Checks.Queries.GetCheckResult
{
    public class CheckParameterDto : IMapFrom<CheckParameter>
    {
        public string Description { get; set; } = string.Empty;
        public string Method { get; set; } = "На оборудовании";
        public bool Result { get; set; }
        public DateTime Date { get; set; }
        public string Comment { get; set; } = string.Empty;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CheckParameter, CheckParameterDto>();
        }
    }
}
