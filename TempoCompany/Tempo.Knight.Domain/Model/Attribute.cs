using Tempo.Common.Setup.Repository;

namespace Tempo.Knight.Domain.Model
{
    public class Attribute : Entity<Guid>
    {
        public required string Name { get; set; }

    }
}
