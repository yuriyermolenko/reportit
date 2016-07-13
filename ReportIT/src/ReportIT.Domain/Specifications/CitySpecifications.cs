using ReportIT.Domain.Aggregates.CityAgg;
using ReportIT.Domain.Specifications.Base;

namespace ReportIT.Domain.Specifications
{
    public static class CitySpecifications
    {
        public static Specification<City> ById(int cityId)
        {
            return new DirectSpecification<City>(city => city.Id == cityId);
        }

        public static Specification<City> ByName(string name)
        {
            return new DirectSpecification<City>(city => city.Name == name);
        }
    }
}
