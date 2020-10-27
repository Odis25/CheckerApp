﻿using AutoMapper;
using CheckerApp.Application.Common.Mappings;
using CheckerApp.Application.Hardwares.Queries;
using CheckerApp.Domain.Entities.CheckEntities;
using System.Collections.Generic;

namespace CheckerApp.Application.Checks.Queries.GetCheckResultFile
{
    public class HardwareCheckDto : IMapFrom<HardwareCheck>
    {
        public HardwareDto Hardware { get; set; }
        public IEnumerable<CheckParameterDto> CheckParameters { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<HardwareCheck, HardwareCheckDto>();
        }
    }
}