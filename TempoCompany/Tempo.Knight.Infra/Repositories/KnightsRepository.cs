

using Microsoft.EntityFrameworkCore;
using Tempo.Common.Setup.Service;
using Tempo.Knight.Domain.Repositories;

namespace Tempo.Knight.Infra.Repositories
{
    /// <summary>
    /// Responsability for acess database objet/entity Kninghts
    /// Here we were using generic herence the DAD
    /// </summary>
    public class KnightsRepository : BaseRepository<KnightDbContext, Domain.Model.Knight, Guid>, IKnightsRepository
    {
        public KnightsRepository(KnightDbContext context) : base(context) { }

    }
}
