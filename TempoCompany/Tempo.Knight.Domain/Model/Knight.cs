using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using Tempo.Common.Setup.Repository;

namespace Tempo.Knight.Domain.Model
{
    public class Knight: Entity<Guid>
    {
        public required string Name { get; set; }
        public required string Nickname { get; set; }
        public DateTime Birthday { get; set; }
        public ICollection<Weapon> Weapons { get; set; } = new List<Weapon>();
        [NotMapped]
        public required Dictionary<string, int> Attributes { get; set; } = new Dictionary<string, int>();
        public required string KeyAttribute { get; set; }
        public required string CharacterType { get; set; }
        public bool HallOfHeroes { get; set; } = false;


    }
}
