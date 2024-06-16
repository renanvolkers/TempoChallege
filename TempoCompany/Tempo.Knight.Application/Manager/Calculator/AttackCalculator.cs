using Tempo.Knight.Domain.Model.Calculator;

namespace Tempo.Knight.Application.Manager.Calculator
{
    public class AttackCalculator : IAttackCalculator
    {
        /// <summary>
        /// calculates the attack value of a Knight in the domain 
        /// of a game or character modeling system.
        /// </summary>
        /// <param name="knight"></param>
        /// </returns>
        public int CalculateAttack(Knight.Domain.Model.Knight knight)
        {
            int keyAttributeModifier = GetAttributeModifier(knight.Attributes.GetValueOrDefault(knight.KeyAttribute,0));
            int equippedWeaponModifier = knight.Weapons.Where(w => w.Equipped).Sum(w => w.Mod);

            return 10 + keyAttributeModifier + equippedWeaponModifier;
        }
        /// <summary>
        /// Rule for define values point atrribute
        /// </summary>
        /// <param name="attributeValue"></param>
        /// <returns></returns>
        private int GetAttributeModifier(int attributeValue)
        {
            if (attributeValue >= 0 && attributeValue <= 8)
                return -2;
            if (attributeValue >= 9 && attributeValue <= 10)
                return -1;
            if (attributeValue >= 11 && attributeValue <= 12)
                return 0;
            if (attributeValue >= 13 && attributeValue <= 15)
                return 1;
            if (attributeValue >= 16 && attributeValue <= 18)
                return 2;
            if (attributeValue >= 19 && attributeValue <= 20)
                return 3;

            return 0;
        }
    }
}
