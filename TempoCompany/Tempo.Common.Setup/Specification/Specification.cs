using System.Linq.Expressions;

namespace Tempo.Common.Setup.Specification
{
    /// <summary>
    /// Abstract Generic for EXPRESSION in function Lambda.
    /// specification pattern outlines a business rule that is combinable with other business rules.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class Specification<T>
        {
            private static readonly Specification<T> All = new IdentitySpecification<T>();

            public bool IsSatisfiedBy(T entity)
            {
                var predicate = ToExpression().Compile();
                return predicate(entity);
            }

            public abstract Expression<Func<T, bool>> ToExpression();


        }
    
}
