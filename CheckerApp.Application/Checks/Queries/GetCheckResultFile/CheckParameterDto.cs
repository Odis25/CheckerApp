using AutoMapper;
using CheckerApp.Application.Common.Mappings;
using CheckerApp.Domain.Entities.CheckEntities;
using System;

namespace CheckerApp.Application.Checks.Queries.GetCheckResultFile
{
    public class CheckParameterDto : IMapFrom<CheckParameter>
    {
        public string Description { get; set; }
        public string Method { get; set; }
        public bool Result { get; set; }
        public DateTime Date { get; set; }
        public string Comment { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CheckParameter, CheckParameterDto>();
        }
    }
}
