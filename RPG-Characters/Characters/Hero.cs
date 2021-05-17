using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Characters
{
    public abstract class Hero
    {
        public string Name { get; set; }
        protected int Level { get; set; }
        public double Dps { get; set; }
        
        public PrimaryAttributes primaryAttributes;
        protected PrimaryAttributes TotalPrimaryAttributes { get; set; }
        public SecondaryAttributes SecondaryAttributes { get; set; } = new SecondaryAttributes();
        protected Dictionary<Slots, Item> UsedItems { get; set; } = new Dictionary<Slots, Item>()
        {
            {Slots.Head, new Armor()},
            {Slots.Body, new Armor()},
            {Slots.Legs, new Armor()},
            {Slots.Weapon, new Weapon()}
        };
        protected List<WeaponTypes> EquipWeapons { get; set; } = new List<WeaponTypes>();
        protected List<ArmorTypes> EquipArmors { get; set; } = new List<ArmorTypes>();
        
        protected Hero(string name)
        {
            Name = name;
            Level = 1;
            primaryAttributes = new PrimaryAttributes();

        }

        /// SUMMARY
        /// Increase level and updates new primary attributes
        public abstract void LevelUp(int level);

        /// SUMMARY
        /// To increase primary values according to number of levels increased
        protected abstract void UpdatedPrimaryAttributes(int numOfLevels);


        /// SUMMARY
        /// Calls the methods to get total primary attributes, secondary attributes and DamagePerSecond
        protected void GetAttributes()
        {
            GetTotalPrimaryAttributes();
            GetSecondaryAttributes();
            DamagePerSecond();
        }

        /// SUMMARY
        /// Gets total primary attributes, with armor attributes. 
        protected void GetTotalPrimaryAttributes()
        {
            PrimaryAttributes tempPrimaryAttributes = new PrimaryAttributes();
            tempPrimaryAttributes += primaryAttributes;

            List<Armor> equippedArmors = UsedItems.Where(e => e.Value.ItemSlot != Slots.Weapon)
                .Select(e => e.Value as Armor).ToList();

            foreach (Armor equippedArmor in equippedArmors)
            {
                tempPrimaryAttributes += equippedArmor.Attributes;
            }

            TotalPrimaryAttributes = tempPrimaryAttributes;
        }

        /// SUMMARY
        /// Gets total secondary attributes according to its total primary attributes
  
        protected void GetSecondaryAttributes()
        {
            SecondaryAttributes.Health = TotalPrimaryAttributes.Vitality * 10;
            SecondaryAttributes.ArmorRating = TotalPrimaryAttributes.Strength + primaryAttributes.Dexterity;
            SecondaryAttributes.ElementalResistance = TotalPrimaryAttributes.Intelligence;
        }


        public String EquipItem(Weapon weapon)
        {
            if (EquipWeapons.Contains(weapon.WeaponType) && Level >= weapon.ItemLevel)
            {
                UsedItems[Slots.Weapon] = weapon;
                GetAttributes();
                return ($"{weapon.ItemName} Equipped");
            }
            else
            {
                throw new InvalidWeaponException();
            }
        }

        public String EquipItem(Armor armor)
        {
            if (EquipArmors.Contains(armor.ArmorType) && Level >= armor.ItemLevel)
            {
                UsedItems[armor.ItemSlot] = armor;
                GetAttributes();
                return $"{armor.ItemName} Equipped";
            }
            else
            {
                throw new InvalidArmorException();
            }  
        }

        public abstract void DamagePerSecond();

        public void DisplayCharacterInfo()
        {
            GetAttributes();
            StringBuilder characterSheet = new StringBuilder("Character Stats:\n");
            characterSheet.AppendLine($"Name: {Name}");
            characterSheet.AppendLine($"Level: {Level}");
            characterSheet.AppendLine($"Strength: {TotalPrimaryAttributes.Strength}");
            characterSheet.AppendLine($"Dexterity: {TotalPrimaryAttributes.Dexterity}");
            characterSheet.AppendLine($"Intelligence: {TotalPrimaryAttributes.Intelligence}");
            characterSheet.AppendLine($"Health: {SecondaryAttributes.Health}");
            characterSheet.AppendLine($"Armor Rating: {SecondaryAttributes.ArmorRating}");
            characterSheet.AppendLine($"Elemental Resistance: {SecondaryAttributes.ElementalResistance}");
            characterSheet.AppendLine($"DPS: {Dps}");

            Console.WriteLine(characterSheet);
        }
    }
}
