using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.CompilerServices;

namespace RPG_Characters
{
    public class Mage : Hero
    {
        public Mage(string name) : base(name)
        {
            EquipArmors.Add(ArmorTypes.Cloth);
            EquipWeapons.Add(WeaponTypes.Staff);
            EquipWeapons.Add(WeaponTypes.Wand);
            primaryAttributes.Vitality = 5;
            primaryAttributes.Strength = 1;
            primaryAttributes.Dexterity = 1;
            primaryAttributes.Intelligence = 8;
            GetAttributes();
        }

        public override void LevelUp(int level)
        {
            if (level <= 0)
            {
                throw new InvalidArgumentException();
            }
            Level += level;
            UpdatedPrimaryAttributes(level);
            GetAttributes();
        }

        protected override void UpdatedPrimaryAttributes(int numOfLevels)
        {
            primaryAttributes.Vitality += 3 * numOfLevels;
            primaryAttributes.Strength += 1 * numOfLevels;
            primaryAttributes.Dexterity += 1 * numOfLevels;
            primaryAttributes.Intelligence += 5 * numOfLevels;
        }
        public override void DamagePerSecond()
        {
            Weapon usedWeapon = UsedItems[Slots.Weapon] as Weapon;
            Dps = (usedWeapon.WeaponAttributes.AttackSpeed * usedWeapon.WeaponAttributes.Damage) *
                     (1 + TotalPrimaryAttributes.Intelligence / 100.0);
        }
    }
}
