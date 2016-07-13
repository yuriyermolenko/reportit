using System;
using System.Linq.Expressions;

namespace ReportIT.Domain.Specifications.Base
{
    /// <summary>
    /// True specification
    /// </summary>
    /// <typeparam name="TEntity">Type of entity in this specification</typeparam>
    public sealed class TrueSpecification<TEntity>
        : Specification<TEntity> where TEntity : class
    {
        #region Specification overrides

        /// <summary>
        /// <see cref=" Specification{TEntity}"/>
        /// </summary>
        /// <returns><see cref=" Specification{TEntity}"/></returns>
        public override Expression<Func<TEntity, bool>> SatisfiedBy()
        {
            const bool result = true;

            Expression<Func<TEntity, bool>> trueExpression = t => result;
            return trueExpression;
        }

        #endregion
    }
}
