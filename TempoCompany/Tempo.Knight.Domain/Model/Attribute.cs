using Tempo.Common.Setup.Repository;

namespace Tempo.Knight.Domain.Model
{
    public class Attribute : Entity<Guid>
    {
        public required string Name { get; set; }
        public int Value { get; set; }

        public required KnightAttribute KnightAttribute { get; set; }
    }
}
