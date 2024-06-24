using System.Linq.Expressions;
using Tempo.Common.Setup.Service;
using Tempo.Knight.Domain.Model;
using Tempo.Knight.Domain.Repositories;

namespace Tempo.Knight.Infra.Repositories
{
    public class KnightAttributeRepository : BaseRepository<KnightDbContext, Domain.Model.KnightAttribute, Guid>, IKnightAttributeRepository
    {
        private KnightDbContext contexto;
        public KnightAttributeRepository(KnightDbContext context) : base(context) {

            contexto = context;
        }
        public async Task<List<Domain.Model.KnightAttribute>> AddAsync(Guid knightiD, List<Guid> attributeIds,string Use = "", params Expression<Func<KnightAttribute, object?>>[] references)
        {
            var attributes = attributeIds.Select(x => new KnightAttribute {
                Id= Guid.NewGuid(), AttributeId = x, KnightId = knightiD ,
                CreatedBy = Use
            }).ToList() ;
            await contexto.AddRangeAsync(attributes);
            await contexto.SaveChangesAsync();
            return attributes;
        }
    }
}
