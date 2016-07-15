using AutoMapper;
using ReportIT.Application.DTO;
using ReportIT.Domain.Aggregates.CityAgg;

namespace ReportIT.Application.Mappings
{
    public class AutomapperProfile : Profile
    {
        public override string ProfileName => "Application Profile";

        public AutomapperProfile()
        {
            CreateMap<City, CityDTO>();
        }
    }
}
