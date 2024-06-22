using Tempo.Common.Setup;
using Tempo.Knight.Dto.Requests.Weapon;

namespace Tempo.Knight.Dto.Requests.Knight
{
    /// <summary>
    /// Request for insert controller
    /// </summary>
    public class RequestKnight : IRequest
    {
        public string Name { get; set; } = "";
        public string Nickname { get; set; } = "";
        public DateTime Birthday { get; set; }
        public List<RequestWeapon> Weapons { get; set; }
        public List<RequestAttribute> Attributes { get; set; }
        public string KeyAttribute { get; set; }
        public  string CharacterType { get; set; }

        public RequestKnight()
        {
            Name = string.Empty;
            Nickname = string.Empty;
            Birthday = DateTime.Now;
            Weapons = new List<RequestWeapon>();
            KeyAttribute = string.Empty;
            Attributes =new List<RequestAttribute>();
            CharacterType = string.Empty;
        }
    }
}
