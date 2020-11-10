using AutoMapper;
using CheckerApp.Application.Common.Mappings;
using CheckerApp.Domain.Entities.HardwareEntities;

namespace CheckerApp.Application.Hardwares.Queries
{
    public class NetworkAdapterDto : IMapFrom<NetworkAdapter>
    {
        public int Id { get; set; }
        public string IP { get; set; }
        public string MacAddress { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<NetworkAdapter, NetworkAdapterDto>();
        }
    }
}
