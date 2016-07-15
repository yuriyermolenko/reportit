using System.Collections.Generic;
using ReportIT.Application.DTO;
using ReportIT.DataAccess.UnitOfWork.Base;
using System.Linq;
using ReportIT.Application.Extensions;
using ReportIT.Domain.Aggregates.CityAgg;

namespace ReportIT.Application.Services
{
    public class CityService : ICityService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CityService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<CityDTO> GetAll()
        {
            var cities = _unitOfWork.CityRepository.All();

            return cities.Select(elem => elem.Create<City, CityDTO>());
        }
    }
}
