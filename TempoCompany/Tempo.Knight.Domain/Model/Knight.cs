
using Tempo.Common.Setup.Repository;

namespace Tempo.Knight.Domain.Model
{
    public class Knight: Entity<Guid>
    {
        public required string Name { get; set; }
        public required string Nickname { get; set; }
        public DateTime Birthday { get; set; }
        public int Age { get => (DateTime.Today.Year - Birthday.Year); }

        public required List<Weapon> Weapons { get; set; }
        public required Dictionary<string, int> Attributes { get; set; }
        public required string KeyAttribute { get; set; }
        public required string CharacterType { get; set; }
        public bool HallOfHeroes { get; set; } = false;


    }
}
