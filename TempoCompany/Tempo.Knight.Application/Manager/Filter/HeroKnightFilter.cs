using Tempo.Knight.Domain.Repositories;

namespace Tempo.Knight.Application.Manager.Filter
{
    public class HeroKnightFilter
    {
        /// <summary>
        /// the specification pattern is a particular software design pattern, 
        /// whereby business rules can be recombined by chaining the
        /// Filter Specific for heroHninght
        /// Here add another kind filter 
        /// </summary>
        public bool CanHandle(string filter) => filter == "heroes";

        public async Task<IEnumerable<Knight.Domain.Model.Knight>> ApplyFilterAsync(IKnightsRepository repository,string filter)
        {
            return await repository.GetAllAsync(x => x.CharacterType== filter);
        }
    }
}
