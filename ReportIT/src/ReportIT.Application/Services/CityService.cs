using System.Collections.Generic;
using ReportIT.Application.DTO;

namespace ReportIT.Application.Services
{
    public class CityService : ICityService
    {
        public IEnumerable<CityDTO> GetAll()
        {
            return new List<CityDTO> { new CityDTO { Id = 1, Name = "Nizhny Novgorod" } };
        }
    }
}
