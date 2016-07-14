using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ReportIT.DataAccess.UnitOfWork.Base
{
    public interface IDbContext
    {
        EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
        DbSet<TEntity> DbSet<TEntity>() where TEntity : class;
        int SaveChanges();
        void Dispose();
    }
}
