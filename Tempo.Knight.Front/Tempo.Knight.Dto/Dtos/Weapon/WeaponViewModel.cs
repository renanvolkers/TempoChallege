namespace Tempo.Knight.Dto.Dtos.Weapon
{
    public class WeaponViewModel
    {
        public string Name { get; set; } = string.Empty;
        public int Mod { get; set; }
        public string Attr { get; set; } = string.Empty;
        public bool Equipped { get; set; }

        public WeaponViewModel(string name, int mod, string attr, bool equipped)
        {
            Name = name;
            Mod = mod;
            Attr = attr;
            Equipped = equipped;
        }
        public WeaponViewModel()
        {

        }
    }
}
