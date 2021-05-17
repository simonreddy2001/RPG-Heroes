using RPG_Characters;
using System;
using Xunit;

namespace RpG_CharactersTest
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Warrior warrior = new Warrior("sss");
            Assert.Equal(10, warrior.primaryAttributes.Vitality);
            Assert.Equal(5, warrior.primaryAttributes.Strength);
            Assert.Equal(2, warrior.primaryAttributes.Dexterity);
            Assert.Equal(1, warrior.primaryAttributes.Intelligence);
        }
        [Fact]
        public void Test2()
        {
            Warrior warrior = new Warrior("sss");
            warrior.LevelUp(2);
            Assert.Equal(20, warrior.primaryAttributes.Vitality);
            Assert.Equal(11, warrior.primaryAttributes.Strength);
            Assert.Equal(6, warrior.primaryAttributes.Dexterity);
            Assert.Equal(3, warrior.primaryAttributes.Intelligence);
        }
        [Fact]
        public void Test3()
        {
            Ranger ranger = new Ranger("sss");
            Assert.Equal(8, ranger.primaryAttributes.Vitality);
            Assert.Equal(1, ranger.primaryAttributes.Strength);
            Assert.Equal(7, ranger.primaryAttributes.Dexterity);
            Assert.Equal(1, ranger.primaryAttributes.Intelligence);
        }
        [Fact]
        public void Test4()
        {
            Ranger ranger = new Ranger("sss");
            ranger.LevelUp(2);
            Assert.Equal(12, ranger.primaryAttributes.Vitality);
            Assert.Equal(3, ranger.primaryAttributes.Strength);
            Assert.Equal(17, ranger.primaryAttributes.Dexterity);
            Assert.Equal(3, ranger.primaryAttributes.Intelligence);
        }
        [Fact]
        public void Test5()
        {
            Rogue rogue = new Rogue("sss");
            Assert.Equal(8, rogue.primaryAttributes.Vitality);
            Assert.Equal(2, rogue.primaryAttributes.Strength);
            Assert.Equal(6, rogue.primaryAttributes.Dexterity);
            Assert.Equal(1, rogue.primaryAttributes.Intelligence);
        }
        [Fact]
        public void Test6()
        {
            Rogue rogue = new Rogue("sss");
            rogue.LevelUp(2);
            Assert.Equal(14, rogue.primaryAttributes.Vitality);
            Assert.Equal(4, rogue.primaryAttributes.Strength);
            Assert.Equal(14, rogue.primaryAttributes.Dexterity);
            Assert.Equal(3, rogue.primaryAttributes.Intelligence);
        }
        [Fact]
        public void Test7()
        {
            Mage mage = new Mage("sss");
            Assert.Equal(5, mage.primaryAttributes.Vitality);
            Assert.Equal(1, mage.primaryAttributes.Strength);
            Assert.Equal(1, mage.primaryAttributes.Dexterity);
            Assert.Equal(8, mage.primaryAttributes.Intelligence);
        }
        [Fact]
        public void Test8()
        {
            Mage mage = new Mage("sss");
            mage.LevelUp(2);
            Assert.Equal(11, mage.primaryAttributes.Vitality);
            Assert.Equal(3, mage.primaryAttributes.Strength);
            Assert.Equal(3, mage.primaryAttributes.Dexterity);
            Assert.Equal(18, mage.primaryAttributes.Intelligence);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void LevelUp(int level)
        {
            Warrior warrior = new Warrior("sss");

            Assert.Throws<InvalidArgumentException>(() => warrior.LevelUp(level));
        }

        [Fact]
        public void Test9()
        {
            Warrior warrior = new Warrior("sss");
            warrior.LevelUp(2);
            Assert.Equal(200, warrior.SecondaryAttributes.Health);
            Assert.Equal(17, warrior.SecondaryAttributes.ArmorRating);
            Assert.Equal(3, warrior.SecondaryAttributes.ElementalResistance);
        }

    }
}
