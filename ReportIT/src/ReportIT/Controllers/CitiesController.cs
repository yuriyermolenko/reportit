using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ReportIT.Application.Services;
using ReportIT.Application.DTO;

namespace ReportIT.Controllers
{
    [Route("api/[controller]")]
    public class CitiesController : Controller
    {
        private readonly ICityService _cityService;

        public CitiesController(ICityService cityService)
        {
            _cityService = cityService;
        }

        // GET: api/city
        [HttpGet]
        public IEnumerable<CityDTO> Get()
        {
            return _cityService.GetAll();
        }
    }
}
