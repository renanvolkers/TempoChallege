using Tempo.Knight.Application.Domain.Knights;
using Tempo.Knight.Application.Manager.Calculator;
using Tempo.Knight.Application.Services.Knights;
using Tempo.Knight.Application.Specification;
using Tempo.Knight.Application.Validations.Knight;
using Tempo.Knight.Domain.Model;
using Tempo.Knight.Domain.Model.Calculator;
using Tempo.Knight.Domain.Repositories;
using Tempo.Knight.Dto.Requests.Knight;
using Tempo.Knight.Dto.Responses;
using FluentValidation;
using Tempo.Common.Setup.Api;
using Tempo.Knight.Infra.Repositories;

namespace Tempo.Knight.Api.Config
{
    public static class IocExtension
    {
        public static void AddSevicesTempo(this IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddScoped<IKnightsRepository, KnightsRepository>();
            services.AddScoped<IKnightService, KnightService>();
            services.AddScoped<IFilterStrategy<Domain.Model.Knight>, FilterKnightsByHeroesSpecification>();
            services.AddScoped<IManagerCalculator<Domain.Model.Knight, ResponseKnight>, ManagerCalculator>();
            services.AddScoped<IAttackCalculator, AttackCalculator>();
            services.AddScoped<IAttributeRepository, AttributeRepository>();
            services.AddScoped<IKnightAttributeRepository, KnightAttributeRepository>();

            services.AddScoped<IExperienceCalculator, ExperienceCalculator>();
            services.AddScoped<ICombatTrainingCalculator, CombatTrainingCalculator>();
            services.AddTransient<IValidator<RequestKnight>, AddKnightValidator>();
            services.AddTransient<TempoApiController>();
        }
    }

}
