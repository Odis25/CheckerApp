﻿using AutoMapper;
using CheckerApp.Application.Common.Mappings;
using CheckerApp.Domain.Entities.HardwareEntities;

namespace CheckerApp.Application.Contracts.Queries.GetContractsList
{
    public class HardwareDto : IMapFrom<Hardware>
    {
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Hardware, HardwareDto>();
        }
    }
}