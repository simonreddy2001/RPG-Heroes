using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.CompilerServices;

namespace RPG_Characters
{
    public class Warrior : Hero
    {
        public Warrior(string name) : base(name)
        {
            EquipArmors.Add(ArmorTypes.Mail);
            EquipArmors.Add(ArmorTypes.Plate);
            EquipWeapons.Add(WeaponTypes.Axe);
            EquipWeapons.Add(WeaponTypes.Hammer);
            EquipWeapons.Add(WeaponTypes.Sword);
            primaryAttributes.Vitality = 10;
            primaryAttributes.Strength = 5;
            primaryAttributes.Dexterity = 2;
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
            primaryAttributes.Vitality += 5 * numOfLevels;
            primaryAttributes.Strength += 3 * numOfLevels;
            primaryAttributes.Dexterity += 2 * numOfLevels;
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
