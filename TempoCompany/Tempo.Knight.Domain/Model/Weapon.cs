
using Tempo.Common.Setup.Repository;

namespace Tempo.Knight.Domain.Model
{
    public class Weapon: Entity<Guid>
    {
        public required string Name { get; set; }
        public int Mod { get; set; }
        public required string Attr { get; set; }
        public bool Equipped { get; set; }
    }
}
