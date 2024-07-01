using Tempo.Knight.Dto.Dtos.Knight;
using Tempo.Knight.Dto.Dtos.Weapon;

namespace Tempo.Knight.WebApp.Components.Pages.KnightForm.Create
{


    public class CreateKnightViewModel 
    {

        public KnightViewModel knightViewModel { get; set; } = new KnightViewModel();
        public CreateKnightViewModel()
        {

        }
        public List<AttributeViewModel> tributes = new List<AttributeViewModel>
    {
        new AttributeViewModel { Name = "Dexterity"},
        new AttributeViewModel { Name = "Wisdom" },
        new AttributeViewModel { Name = "Constitution" },
        new AttributeViewModel { Name = "Strength" },
        new AttributeViewModel { Name = "Intelligence" },
        new AttributeViewModel { Name = "Charisma" }
,
    };




        public WeaponViewModel WeaponSingle = new WeaponViewModel();
        public void ToggleCardSelection(AttributeViewModel tribute)
        {
            this.tributes.ForEach(tribute_ =>
            {
                if (tribute.Name == tribute_.Name)
                {
                    tribute_.Selected = !tribute.Selected;
                    WeaponSingle.Attr = tribute.Name;
                }
                else
                {
                    tribute_.Selected = false;
                }
            });

        }

        public void AddWeapon()
        {
            knightViewModel.Weapons.Add(new WeaponViewModel
            {
                Name = WeaponSingle.Name,
                Mod = WeaponSingle.Mod,
                Attr = WeaponSingle.Attr,
                Equipped = true
            });
            WeaponSingle = new WeaponViewModel(); // Reset the weapon form
        }

        public void RemoveWeapon(WeaponViewModel weapon)
        {
            knightViewModel.Weapons.Remove(weapon);
        }
    }





}
