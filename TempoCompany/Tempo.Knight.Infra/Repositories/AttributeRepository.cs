using Microsoft.EntityFrameworkCore;
using Tempo.Common.Setup.Service;
using Tempo.Knight.Domain.Repositories;

namespace Tempo.Knight.Infra.Repositories
{
    public class AttributeRepository : BaseRepository<DbContext, Domain.Model.Attribute, Guid>, IAttributeRepository
    {
        public AttributeRepository(DbContext context) : base(context) { }

    }
}
