using System.Linq.Expressions;

namespace Tempo.Knight.Domain.Model
{
    /// <summary>
    /// Violation of SOLID in the principle: Open and closed principle can be resolved using the 
    /// Specification design pattern as happens when using filter in the query.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IFilterStrategy<T> where T : class
    {
        Expression<Func<T, bool>> ToExpression();
        void InputFilter(string filter);
        bool IsSatisfiedBy(T entity);
    }
}
