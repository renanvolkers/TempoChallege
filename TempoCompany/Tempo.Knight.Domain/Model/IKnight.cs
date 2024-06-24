namespace Tempo.Knight.Domain.Model
{
    public interface IKnight
    {
        public  string Name { get; set; }
        public string Nickname { get; set; }
        public DateTime Birthday { get; set; }
        public  string CharacterType { get; set; }
        public bool HallOfHeroes { get; set; } 
        public double CombatTraining { get; set; }
    }
}
