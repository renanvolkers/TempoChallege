using Tempo.Common.Setup.Service;
using Tempo.Knight.Domain.Repositories;

namespace Tempo.Knight.Infra.Repositories
{
    public class WeaponRepository : BaseRepository<KnightDbContext, Domain.Model.Weapon, Guid>, IWeaponRepository
    {
        public WeaponRepository(KnightDbContext context) : base(context) { }

    }
}
