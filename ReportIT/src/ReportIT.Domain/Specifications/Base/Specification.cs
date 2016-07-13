﻿using ReportIT.Domain.Specifications.Base;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;

namespace ReportIT.Domain.Specifications.Base
{
    /// <summary>
    /// Represents a Expression Specification
    /// <remarks>
    /// Specification overload operators for create AND,OR or NOT specifications.
    /// </remarks>
    /// </summary>
    /// <typeparam name="TEntity">Type of item in the criteria</typeparam>
    public abstract class Specification<TEntity> : ISpecification<TEntity>
         where TEntity : class
    {
        #region ISpecification<TEntity> Members

        /// <summary>
        /// IsSatisFied Specification pattern method,
        /// </summary>
        /// <returns>Expression that satisfy this specification</returns>
        public abstract Expression<Func<TEntity, bool>> SatisfiedBy();

        #endregion

        #region Override Operators

        /// <summary>
        ///  And operator
        /// </summary>
        /// <param name="leftSideSpecification">left operand in this AND operation</param>
        /// <param name="rightSideSpecification">right operand in this AND operation</param>
        /// <returns>New specification</returns>
        public static Specification<TEntity> operator &(Specification<TEntity> leftSideSpecification, Specification<TEntity> rightSideSpecification)
        {
            return new AndSpecification<TEntity>(leftSideSpecification, rightSideSpecification);
        }

        /// <summary>
        /// Or operator
        /// </summary>
        /// <param name="leftSideSpecification">left operand in this OR operation</param>
        /// <param name="rightSideSpecification">left operand in this OR operation</param>
        /// <returns>New specification </returns>
        public static Specification<TEntity> operator |(Specification<TEntity> leftSideSpecification, Specification<TEntity> rightSideSpecification)
        {
            return new OrSpecification<TEntity>(leftSideSpecification, rightSideSpecification);
        }

        /// <summary>
        /// Not specification
        /// </summary>
        /// <param name="specification">Specification to negate</param>
        /// <returns>New specification</returns>
        public static Specification<TEntity> operator !(Specification<TEntity> specification)
        {
            return new NotSpecification<TEntity>(specification);
        }

        /// <summary>
        /// Override operator false, only for support AND OR operators
        /// </summary>
        /// <param name="specification">Specification instance</param>
        /// <returns>See False operator in C#</returns>
        public static bool operator false(Specification<TEntity> specification)
        {
            return false;
        }

        /// <summary>
        /// Override operator True, only for support AND OR operators
        /// </summary>
        /// <param name="specification">Specification instance</param>
        /// <returns>See True operator in C#</returns>
        public static bool operator true(Specification<TEntity> specification)
        {
            return true;
        }

        #endregion
    }
}
