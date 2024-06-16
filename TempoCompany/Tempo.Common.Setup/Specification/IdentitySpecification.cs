using System.Linq.Expressions;

namespace Tempo.Common.Setup.Specification
{

    /// <summary>
    /// Abstract Generic for EXPRESSION in function Lambda.
    /// specification pattern outlines a business rule that is combinable with other business rules.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal sealed class IdentitySpecification<T> : Specification<T>
    {
        public override Expression<Func<T, bool>> ToExpression()
        {
            return x => true;
        }
    }
}
