using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.CompilerServices;

namespace RPG_Characters
{
    public class Ranger : Hero
    {
        public Ranger(string name) : base(name)
        {
            EquipArmors.Add(ArmorTypes.Leather);
            EquipArmors.Add(ArmorTypes.Mail);
            EquipWeapons.Add(WeaponTypes.Bow);
            primaryAttributes.Vitality = 8;
            primaryAttributes.Strength = 1;
            primaryAttributes.Dexterity = 7;
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
            primaryAttributes.Vitality += 2 * numOfLevels;
            primaryAttributes.Strength += 1 * numOfLevels;
            primaryAttributes.Dexterity += 5 * numOfLevels;
            primaryAttributes.Intelligence += 1 * numOfLevels;
        }

        public override void DamagePerSecond()
        {
            Weapon equippedWeapon = UsedItems[Slots.Weapon] as Weapon;
            Dps = (equippedWeapon.WeaponAttributes.AttackSpeed * equippedWeapon.WeaponAttributes.Damage) *
                     (1 + TotalPrimaryAttributes.Strength / 100.0);
        }
    }
}
