
using Tempo.Common.Setup.Api;
using System.Diagnostics.CodeAnalysis;

namespace Tempo.Knight.Dto.Responses
{
    public class ResponseKnight :Response<Guid>
    {
        public  string Name { get; set; }
        public  string Nickname { get; set; }
        public DateTime Birthday { get; set; }
        public int Age { get => (DateTime.Today.Year - Birthday.Year); }
        public int Attack { get; set; }
        public int Experience { get; set; }
        public  List<ResponseWeapon> Weapons { get; set; }
        public List<RequestAttribute> Attributes { get; set; } = new List<RequestAttribute>();

        public string KeyAttribute { get; set; }
        public bool HallOfHeroes { get; set; }

        [SetsRequiredMembers]
        public ResponseKnight(Guid id,string name, string nickname, DateTime birthday, List<ResponseWeapon> weapons,string keyAttribute, List<RequestAttribute> attributes,bool hallOfHeroes, int expirience, int attack)
        {
            Id = id;
            Name = name;
            Nickname = nickname;
            Birthday = birthday;
            Weapons = weapons;
            KeyAttribute = keyAttribute;
            Attributes = attributes;
            Experience = expirience;
            Attack = attack;
            HallOfHeroes = hallOfHeroes;
        }

        public ResponseKnight() {
            this.Id = Guid.NewGuid();
            Name = string.Empty;
            Nickname = string.Empty;
            Birthday = DateTime.Now;
            Weapons = new List<ResponseWeapon>();
            KeyAttribute = string.Empty;
            Attributes =new List<RequestAttribute>();
            Experience = 0;
            Attack = 0;
            HallOfHeroes = false;
        }
    }
}
