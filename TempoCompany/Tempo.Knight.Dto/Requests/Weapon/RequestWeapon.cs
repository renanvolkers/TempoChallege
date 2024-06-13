
using Tempo.Common.Setup;

namespace Tempo.Knight.Dto.Requests.Weapon
{

    /// <summary>
    /// Request for insert controller
    /// </summary>
    public class RequestWeapon : IRequest
    {
        public required string Name { get; set; }
        public int Mod { get; set; }
        public required string Attr { get; set; }
        public bool Equipped { get; set; }
    }
}
