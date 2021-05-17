using RPG_Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RpG_CharactersTest
{
  public  class UnitTest2
    {
        [Fact]
        public void InitialValues()
        {
            Warrior warrior = new Warrior("sss");
            double expected = 1 * (1 + (5 / 100.0));
            double actual = warrior.Dps;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void InitialValuesWarriorWeapon()
        {
            Warrior warrior = new Warrior("sss");
            Weapon testAxe = new Weapon()
            {
                ItemName = "Common Axe",
                ItemLevel = 1,
                ItemSlot = Slots.Weapon,
                WeaponType = WeaponTypes.Axe,
                WeaponAttributes = { Damage = 7, AttackSpeed = 1.1 }
            };
            warrior.EquipItem(testAxe);
            double expected = (7 * 1.1) * (1 + (5 / 100.0));
            double actual = warrior.Dps;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void InitialValuesWarriorWeaponArmor()
        {
            Warrior warrior = new Warrior("sss");
            Weapon testAxe = new Weapon()
            {
                ItemName = "Common Axe",
                ItemLevel = 1,
                ItemSlot = Slots.Weapon,
                WeaponType = WeaponTypes.Axe,
                WeaponAttributes = { Damage = 7, AttackSpeed = 1.1 }
            };
            Armor testPlateBody = new Armor()
            {
                ItemName = "Common plate body armor",
                ItemLevel = 1,
                ItemSlot = Slots.Body,
                ArmorType = ArmorTypes.Plate,
                Attributes = { Vitality = 2, Strength = 1 }
            };
            warrior.EquipItem(testAxe);
            warrior.EquipItem(testPlateBody);

            double expected = (7 * 1.1) * (1 + ((5 + 1) / 100.0));
            double actual = warrior.Dps;

            Assert.Equal(expected, actual);
        }
         [Fact]
         public void InvalidWeaponShouldThrowException()
         {
             Weapon testAxe = new Weapon()
             {
                 ItemName = "Common Axe",
                 ItemLevel = 2,
                 ItemSlot = Slots.Weapon,
                 WeaponType = WeaponTypes.Axe,
                 WeaponAttributes = { Damage = 7, AttackSpeed = 1.1 }
             };
             Warrior warrior = new Warrior("sss");

             Assert.Throws<InvalidWeaponException>(() => warrior.EquipItem(testAxe));
         }

         [Fact]
         public void InvalidArmorShouldThrowException()
         {
             Armor testPlateBody = new Armor()
             {
                 ItemName = "Common plate body armor",
                 ItemLevel = 2,
                 ItemSlot = Slots.Body,
                 ArmorType = ArmorTypes.Plate,
                 Attributes = { Vitality = 2, Strength = 1 }
             };
             Warrior warrior = new Warrior("sss");

             Assert.Throws<InvalidArmorException>(() => warrior.EquipItem(testPlateBody));
         }

         [Fact]
         public void InvalidWeaponTypeShouldThrowException()
         {
             Weapon testBow = new Weapon()
             {
                 ItemName = "Common Bow",
                 ItemLevel = 1,
                 ItemSlot = Slots.Weapon,
                 WeaponType = WeaponTypes.Bow,
                 WeaponAttributes = { Damage = 12, AttackSpeed = 0.8 }
             };
             Warrior warrior = new Warrior("sss");

             Assert.Throws<InvalidWeaponException>(() => warrior.EquipItem(testBow));
         }

         [Fact]
         public void InvalidArmorTypeShouldThrowException()
         {
             Armor testClothHead = new Armor()
             {
                 ItemName = "Common cloth head armor",
                 ItemLevel = 1,
                 ItemSlot = Slots.Head,
                 ArmorType = ArmorTypes.Cloth,
                 Attributes = { Vitality = 1, Intelligence = 5 }
             };
             Warrior warrior = new Warrior("sss");

             Assert.Throws<InvalidArmorException>(() => warrior.EquipItem(testClothHead));
         }

        [Fact]
        public void EquippedWeapon()
        {
            Weapon testaxe = new Weapon()
            {
                ItemName = "common axe",
                ItemLevel = 1,
                ItemSlot = Slots.Weapon,
                WeaponType = WeaponTypes.Axe,
                WeaponAttributes = { Damage = 7, AttackSpeed = 1.1 }
            };
            Warrior warrior = new Warrior("sss");

            string expected = "common axe Equipped";
            string actual = warrior.EquipItem(testaxe);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void EquippedArmor()
        {
            Armor testPlateBody = new Armor()
            {
                ItemName = "Common plate body armor",
                ItemLevel = 1,
                ItemSlot = Slots.Body,
                ArmorType = ArmorTypes.Plate,
                Attributes = { Vitality = 2, Strength = 1 }
            };
            Warrior warrior = new Warrior("sss");

            string expected = "Common plate body armor Equipped";
            string actual = warrior.EquipItem(testPlateBody);

            Assert.Equal(expected, actual);
        }


    }
}
