using AutoMapper;
using Tempo.Knight.Application.Domain.Knights;
using Tempo.Knight.Domain.Model;
using Tempo.Knight.Domain.Model.Calculator;
using Tempo.Knight.Domain.Repositories;
using Tempo.Knight.Dto.Requests.Knight;
using Tempo.Knight.Dto.Responses;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Linq.Expressions;
using Tempo.Common.Setup.Api;
using Tempo.Common.Setup.Error;
using Tempo.Common.Setup.Service;

namespace Tempo.Knight.Application.Services.Knights
{
    /// <summary>
    /// KnightService is use dependency injection in construct.
    /// Provide service Knight consume for Controllers
    /// IManagerCalculator  dependency inversion principle 
    /// IFilterStrategy  Use Pattern Specification for high cohesion and low coupling
    /// 
    /// </summary>
    public class KnightService : TempoBaseService<Knight.Domain.Model.Knight, ResponseKnight, IKnightsRepository>, IKnightService
    {
        private readonly IFilterStrategy<Knight.Domain.Model.Knight> _filterStrategy;
        private readonly IManagerCalculator<Knight.Domain.Model.Knight, ResponseKnight> _managerCalculator;
        private readonly IAttributeRepository _attributeRepository;
        private readonly IKnightAttributeRepository _knightAttributeRepository;

        public KnightService(IMapper mapper, IKnightsRepository knightsRepository, IAttributeRepository attributeRepository, IKnightAttributeRepository knightAttributeRepository, IFilterStrategy<Knight.Domain.Model.Knight> filterStrategy,
            IManagerCalculator<Knight.Domain.Model.Knight, ResponseKnight> managerCalculator) : base(mapper, knightsRepository)
        {
            _filterStrategy = filterStrategy;
            _managerCalculator = managerCalculator;
            _attributeRepository = attributeRepository;
            _knightAttributeRepository = knightAttributeRepository;
        }

        public async Task<BaseResponse<List<ResponseKnight>>> GetFilterAsync(string filter = "")
        {
            string [] includes = ["Weapons", "KnightAttributes", "KnightAttributes.Attribute"];
            _filterStrategy.InputFilter(filter);
            var result = (await _repository.GetAllAsync(_filterStrategy.ToExpression(), includes));
            var viewModelResults = new BaseResponse<List<ResponseKnight>>
            {
                Data = _managerCalculator.Calculator(result).ToList(),
            };
            return viewModelResults;
        }

        public virtual async Task<BaseResponse<ResponseKnight>> AddKnightAsync(BaseRequest<RequestKnight> model, params Expression<Func<IModel, object>>[] references)
        {

            if (model.ErrorMessage.Any())
            {
                return new BaseResponse<ResponseKnight>(model.ErrorMessage);
            }
            var requestKnight = model.Data ?? new RequestKnight();
            var attributes = await _attributeRepository.GetAllAsync(x =>true);

            if (!attributes.Any(x => x.Name.ToUpper() == requestKnight.KeyAttribute.ToUpper()))
            {
                model.ErrorMessage.Add(new CustomValidationFailure(requestKnight.KeyAttribute, ErrorMessages.NotFound));
                return new BaseResponse<ResponseKnight>(model.ErrorMessage);
            }

            model.Data?.Attributes.ToList().ForEach(attribute =>
           {
               if (!attributes.Select(attr => attr.Name.ToUpper()).Contains(attribute.Name.ToUpper()))
               {
                   model.ErrorMessage.Add(new CustomValidationFailure(attribute.Name, ErrorMessages.NotFound));
               }

           });
            if (model.ErrorMessage.Any())
            {
                return new BaseResponse<ResponseKnight>(model.ErrorMessage);
            }

            var domainEntity = _mapper.Map<Knight.Domain.Model.Knight>(model.Data);
            var newEntity = await _repository.AddAsync(domainEntity);
            var addAttribs = attributes.Where(x => requestKnight.Attributes.Select(x => x.Name).Contains(x.Name)).Select(x=>x.Id).ToList();
            await _knightAttributeRepository.AddAsync(domainEntity.Id, addAttribs);
            return _mapper.Map<BaseResponse<ResponseKnight>>(newEntity);

        }
    }
}
