namespace Tempo.Knight.WebApp.Components.Pages.KnightForm
{
    public class KnightViewModel
    {
        public required string Name { get; set; }
        public int Age { get; set; }
        public List<WeaponViewModel> Weapons { get; set; } = new();
        public required string KeyAttribute { get; set; }
        public int Attack { get; set; }
        public int Experience { get; set; }
        public Guid Id { get; set; }
    }
}
