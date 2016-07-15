using Microsoft.EntityFrameworkCore;
using ReportIT.DataAccess.UnitOfWork.Base;
using ReportIT.Domain.Specifications.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReportIT.DataAccess.Repositories.Base
{
    public class BaseRepository<TEntity> :
        ICreateRepository<TEntity>,
        IDeleteRepository<TEntity>,
        IReadRepository<TEntity>,
        IUpdateRepository<TEntity> where TEntity : class
    {
        protected IDbContext Context;
        protected DbSet<TEntity> DbSet;

        public BaseRepository(IDbContext context)
        {
            Context = context;
            DbSet = context.DbSet<TEntity>();
        }

        public virtual IEnumerable<TEntity> All(ISpecification<TEntity> specification = null)
        {
            return specification != null ? DbSet.Where(specification.SatisfiedBy()) : DbSet;
        }

        public virtual bool Any(ISpecification<TEntity> specification = null)
        {
            if (specification != null)
            {
                return DbSet.Any(specification.SatisfiedBy());
            }

            return DbSet.Any();
        }

        public virtual IEnumerable<TEntity> Find(params ISpecification<TEntity>[] specifications)
        {
            IQueryable<TEntity> query = AsQueryable();

            query = specifications.Aggregate(
                query, (current, spec) =>
                current.Where(spec.SatisfiedBy()));

            return query.AsEnumerable();
        }

        public virtual TEntity FirstOrDefault(params ISpecification<TEntity>[] specifications)
        {
            var query = AsQueryable();

            query = specifications.Aggregate(
                query, (current, spec) =>
                current.Where(spec.SatisfiedBy()));

            return query.FirstOrDefault();
        }

        public virtual void Insert(TEntity entity)
        {
            DbSet.Add(entity);
        }

        public virtual void Update(TEntity entity)
        {
            DbSet.Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(TEntity entity)
        {
            if (Context.Entry(entity).State == EntityState.Detached)
            {
                DbSet.Attach(entity);
            }

            DbSet.Remove(entity);
        }

        protected IQueryable<TEntity> AsQueryable()
        {
            return DbSet;
        }
    }
}
