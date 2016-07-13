using System;
using System.Linq.Expressions;

namespace ReportIT.Domain.Specifications.Base
{
    /// <summary>
    /// False specification
    /// </summary>
    /// <typeparam name="TEntity">Type of entity in this specification</typeparam>
    public sealed class FalseSpecification<TEntity>
        : Specification<TEntity> where TEntity : class
    {
        #region Specification overrides

        /// <summary>
        /// <see cref=" Specification{TEntity}"/>
        /// </summary>
        /// <returns><see cref=" Specification{TEntity}"/></returns>
        public override Expression<Func<TEntity, bool>> SatisfiedBy()
        {
            const bool result = false;

            Expression<Func<TEntity, bool>> falseExpression = t => result;
            return falseExpression;
        }

        #endregion
    }
}
