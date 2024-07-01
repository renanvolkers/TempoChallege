using Tempo.Knight.Dto.Dtos.Weapon;

namespace Tempo.Knight.Dto.Dtos.Knight
{
    public class KnightViewModel
    {
        public string Name { get; set; } = string.Empty;
        public string Nickname { get; set; } = string.Empty;
        public DateTime Birthday { get; set; }
        public string KeyAttribute { get; set; } = string.Empty;
        public List<WeaponViewModel> Weapons { get; set; } = new();
        public List<AttributeViewModel> Attributes { get; set; } = new();
        public int Age { get; set; }
        public int Attack { get; set; }
        public int Experience { get; set; }
        public Guid Id { get; set; }
        public KnightViewModel()
        {

        }
    }
}
