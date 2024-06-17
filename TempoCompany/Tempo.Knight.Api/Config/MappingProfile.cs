using AutoMapper;
using Tempo.Common.Setup;
using Tempo.Common.Setup.Api;
using Tempo.Knight.Domain.Model;
using Tempo.Knight.Dto.Requests.Knight;
using Tempo.Knight.Dto.Requests.Weapon;
using Tempo.Knight.Dto.Responses;

namespace Tempo.Knight.Api.Config
{
    /// <summary>
    /// Configuration request, response with AutoMapper.
    /// </summary>
    /// <param name="services"></param>
    public class MappingProfile : Profile
    {
        public MapperConfiguration mapperConfig { get; set; }
        public MappingProfile()
        {
            mapperConfig = new MapperConfiguration(cfg =>
           {

               cfg.CreateMap<Domain.Model.Knight, RequestKnight>();
               cfg.CreateMap<RequestUpdateKnight, Domain.Model.Knight>();
               cfg.CreateMap<RequestDeleteKnight, Domain.Model.Knight>();
               cfg.CreateMap<IRequest, Domain.Model.Knight>();


               cfg.CreateMap<RequestUpdateKnight, Domain.Model.Knight>()
                  .ForMember(dest => dest.Nickname, opt => opt.MapFrom(src => src.Nickname));

               cfg.CreateMap<RequestKnight, Domain.Model.Knight>();
               cfg.CreateMap<Domain.Model.Knight, BaseRequest<RequestKnight>>()
                .ForMember(dest => dest.Data, opt => opt.MapFrom(src => src));

               cfg.CreateMap<Domain.Model.Knight, ResponseKnight>();

               cfg.CreateMap<Domain.Model.Knight, BaseResponse<ResponseKnight>>()
               .ForMember(dest => dest.Data, opt => opt.MapFrom(src => src));

               cfg.CreateMap<List<Domain.Model.Knight>, BaseResponse<List<ResponseKnight>>>()
                   .ForMember(dest => dest.Data, opt => opt.MapFrom(src => src));

               cfg.CreateMap<RequestWeapon, Weapon>();
               cfg.CreateMap<Weapon, ResponseWeapon>();

           });
        }
    }
}
