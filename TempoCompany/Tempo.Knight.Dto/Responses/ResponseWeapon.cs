
namespace Tempo.Knight.Dto.Responses
{
    public class ResponseWeapon
    {
        public required string Name { get; set; }
        public int Mod { get; set; }
        public required string Attr { get; set; }
        public bool Equipped { get; set; }
    }
}
