using Tempo.Common.Setup.Service;
using Tempo.Knight.Domain.Repositories;

namespace Tempo.Knight.Infra.Repositories
{
    public class AttributeRepository : BaseRepository<KnightDbContext, Domain.Model.Attribute, Guid>, IAttributeRepository
    {
        public AttributeRepository(KnightDbContext context) : base(context) { }

    }
}
