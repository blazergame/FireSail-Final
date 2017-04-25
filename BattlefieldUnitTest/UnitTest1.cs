using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DandD.Models.Game_Files;
using DandD.Services;

namespace BattlefieldUnitTest
{
    [TestClass]
    public class BattlefieldUnitTest
    {
        [TestMethod]
        public void testSpeedComparisonMonsterFaster()
        {
            Monster m1 = new Monster("slime");
            m1.Dex = 10;
            Character c2 = new Character("Carl");
            c2.Dex = 5;
            var battlefield = new BattlefieldController();
            int speedTest = battlefield.compareSpeed(m1, c2); //returns a 1 if the character has faster DEX
            Assert.AreEqual(1, speedTest);
        }

        [TestMethod]
        public void testSpeedComparisonCharacterFaster()
        {
            Monster m1 = new Monster("slime");
            m1.Dex = 5;
            Character c2 = new Character("Carl");
            c2.Dex = 10;
            var battlefield = new BattlefieldController();
            var speedTest = battlefield.compareSpeed(m1, c2); //returns a 2 if the character has faster DEX
            Assert.AreEqual(speedTest, 2);
        }

        [TestMethod]
        public void testAreEqualSpeedComparison()
        {
            Monster m1 = new Monster("slime");
            m1.Dex = 10;
            Character c2 = new Character("Carl");
            c2.Dex = 10;
            var battlefield = new BattlefieldController();
            var speedTest = battlefield.compareSpeed(m1, c2); // returns a 2 if they DEX are equal.
            Assert.AreEqual(speedTest, 2);
        }

        [TestMethod]
        public void testIsDeadMonster()
        {
            Monster m1 = new Monster("slime");
            m1.Health = 0;
            var battlefield = new BattlefieldController();
            var healthTest = battlefield.isDead(m1);
            Assert.AreEqual(healthTest, true);
        }

        [TestMethod]
        public void testIsNotDeadMonster()
        {
            Monster m1 = new Monster("slime");
            m1.Health = 10;
            var battlefield = new BattlefieldController();
            var healthTest = battlefield.isDead(m1);
            Assert.AreNotEqual(true, healthTest);
        }

        [TestMethod]
        public void testIsDeadCharacter()
        {
            Character c2 = new Character("Carl");
            c2.Health = 0;
            var battlefield = new BattlefieldController();
            var healthTest = battlefield.isDead(c2);
            Assert.AreEqual(healthTest, true);
        }

        [TestMethod]
        public void testIsNotDeadCharacter()
        {
            Character c2 = new Character("Carl");
            c2.Health = 10;
            var battlefield = new BattlefieldController();
            var healthTest = battlefield.isDead(c2);
            Assert.AreEqual(healthTest, false);
        }
    }
}
