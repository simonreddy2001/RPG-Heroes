using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.CompilerServices;

namespace RPG_Characters
{
    public class Rogue : Hero
    {
        public Rogue(string name) : base(name)
        {
            EquipArmors.Add(ArmorTypes.Leather);
            EquipArmors.Add(ArmorTypes.Mail);
            EquipWeapons.Add(WeaponTypes.Dagger);
            EquipWeapons.Add(WeaponTypes.Sword);
            primaryAttributes.Vitality = 8;
            primaryAttributes.Strength = 2;
            primaryAttributes.Dexterity = 6;
            primaryAttributes.Intelligence = 1;
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
            primaryAttributes.Dexterity += 4 * numOfLevels;
            primaryAttributes.Intelligence += 1 * numOfLevels;
        }

        public override void DamagePerSecond()
        {
            Weapon equippedWeapon = UsedItems[Slots.Weapon] as Weapon;
            Dps = (equippedWeapon.WeaponAttributes.AttackSpeed * equippedWeapon.WeaponAttributes.Damage) *
                     (1 + TotalPrimaryAttributes.Dexterity / 100.0);
        }
    }
}
