using ReportIT.Application.DTO;
using System.Collections.Generic;

namespace ReportIT.Application.Services
{
    public interface ICityService
    {
        IEnumerable<CityDTO> GetAll();
    }
}
