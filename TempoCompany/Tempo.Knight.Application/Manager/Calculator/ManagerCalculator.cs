using AutoMapper;
using Tempo.Knight.Domain.Model.Calculator;
using Tempo.Knight.Dto.Responses;

namespace Tempo.Knight.Application.Manager.Calculator
{
    /// <summary>
    /// WHY this it ?Beacause I use of interfaces and dependency injection makes the
    /// code more modular and flexible. New interface implementations can be added or modified without 
    /// having to change the ManagerCalculator.
    /// 
    ///  Dependency Inversion: Instead of the ManagerCalculator class relying directly on 
    /// concrete implementations to calculate attack and experience,
    /// it relies on abstractions (IAttackCalculator and IExperienceCalculator).
    /// This allows different implementations of these interfaces to be
    /// provided without changing the ManagerCalculator logic.
    /// 
    /// </summary>
    public class ManagerCalculator : IManagerCalculator<Knight.Domain.Model.Knight, ResponseKnight>
    {
        private readonly IAttackCalculator _attackCalculator;
        private readonly IExperienceCalculator _experienceCalculator;
        private IMapper _mapper;
        public ManagerCalculator(IMapper mapper, IAttackCalculator attackCalculator, IExperienceCalculator experienceCalculator)
        {
            _attackCalculator = attackCalculator;
            _experienceCalculator = experienceCalculator;
            _mapper = mapper;
        }
        public IEnumerable<ResponseKnight> Calculator(IEnumerable<Knight.Domain.Model.Knight> knights)
        {
            return knights.Select(x => new ResponseKnight(
                x.Id,
                 x.Name,
                 x.Nickname,
                 x.Birthday,
                _mapper.Map<List<ResponseWeapon>>(x.Weapons),
                x.KeyAttribute,
                _mapper.Map<List<RequestAttribute>>(x.KnightAttributes.Select(x=>x.Attribute)),
                x.HallOfHeroes,
                 _experienceCalculator.CalculateExperience(x),
                 _attackCalculator.CalculateAttack(x)
)
             ); ;

        }

    }
}
