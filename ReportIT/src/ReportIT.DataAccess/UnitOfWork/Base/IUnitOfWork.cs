using ReportIT.DataAccess.Repositories.Base;
using ReportIT.Domain.Aggregates.CityAgg;

namespace ReportIT.DataAccess.UnitOfWork.Base
{
    public interface IUnitOfWork
    {
        void Save();

        BaseRepository<City> CityRepository { get; }
    }
}
