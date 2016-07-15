using ReportIT.DataAccess.UnitOfWork.Base;
using System;
using ReportIT.DataAccess.Repositories.Base;
using ReportIT.Domain.Aggregates.CityAgg;

namespace ReportIT.DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly IDbContext _context;

        private bool _disposed;

        private BaseRepository<City> _cityRepository;
        public BaseRepository<City> CityRepository => _cityRepository ?? (_cityRepository = new BaseRepository<City>(_context));
        
        public UnitOfWork(IDbContext context)
        {
            _context = context;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
                _context.Dispose();

            _disposed = true;
        }
    }
}
