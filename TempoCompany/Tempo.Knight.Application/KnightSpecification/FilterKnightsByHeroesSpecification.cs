using Tempo.Common.Setup.Specification;
using Tempo.Common.Setup.Util.Extension;
using Tempo.Knight.Domain.Enum;
using Tempo.Knight.Domain.Model;
using System.Linq.Expressions;

namespace Tempo.Knight.Application.Specification
{
    /// <summary>
    /// the specification pattern is a particular software design pattern, 
    /// whereby business rules can be recombined by chaining the
    /// </summary>
    public sealed class FilterKnightsByHeroesSpecification : Specification<Knight.Domain.Model.Knight>, IFilterStrategy<Knight.Domain.Model.Knight>
    {
        private string? _filterHero;

        public FilterKnightsByHeroesSpecification()
        {
            _filterHero = string.Empty;
        }
        public void InputFilter(string? filterHero)
        {
            _filterHero = filterHero;
        }
        public override Expression<Func<Knight.Domain.Model.Knight,bool>> ToExpression()
        {
            if(FilterCharacterType.Heroes.GetInfo()==_filterHero)
            {
                return knight => knight.CharacterType == _filterHero;
            }
            return allKinghts => true ;
        }
}
}
