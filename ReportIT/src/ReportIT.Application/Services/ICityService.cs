using ReportIT.Application.DTO;
using System.Collections.Generic;

namespace ReportIT.Application.Services
{
    interface ICityService
    {
        IEnumerable<CityDTO> GetAll();
    }
}
