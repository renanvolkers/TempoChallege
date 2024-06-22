using Tempo.Common.Setup.Repository;

namespace Tempo.Knight.Domain.Model
{
    public class Knight: Entity<Guid>
    {
        public required string Name { get; set; }
        public required string Nickname { get; set; }
        public DateTime Birthday { get; set; }
        public ICollection<Weapon> Weapons { get; set; } = new List<Weapon>();
        public ICollection<KnightAttribute> KnightAttributes { get; set; } = new List<KnightAttribute>();
        public required string KeyAttribute { get; set; }
        public required string CharacterType { get; set; }
        public bool HallOfHeroes { get; set; } = false;


    }
}
