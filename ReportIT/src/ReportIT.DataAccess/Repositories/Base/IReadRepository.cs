using ReportIT.Domain.Specifications.Base;
using System.Collections.Generic;

namespace ReportIT.DataAccess.Repositories.Base
{
    internal interface IReadRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> All(ISpecification<TEntity> specification = null);

        IEnumerable<TEntity> Find(params ISpecification<TEntity>[] specifications);

        TEntity FirstOrDefault(params ISpecification<TEntity>[] specifications);
    }
}
