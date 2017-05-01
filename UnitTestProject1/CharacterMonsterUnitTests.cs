using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DandD.Models.Game_Files;
using DandD.Services;

namespace UnitTestProject1
{
    [TestClass]
    public class CharacterMonsterUnitTests
    {
        [TestMethod]
        public void monsterCreationTest()
        {
            Monster m1 = new Monster("slime");
            Assert.AreEqual("slime", m1.Name);      
        }

        [TestMethod]
        public void chracterCreationTest()
        {
            Character m1 = new Character("Benson");
            Assert.AreEqual("Benson", m1.Name);
        }

        [TestMethod]
        public void monsterIsDeadTest()
        {
            Monster m1 = new Monster("slime");
            Assert.AreEqual(true, m1.isDead(0));
        }

        [TestMethod]
        public void characterIsDeadTest()
        {
            Character c1 = new Character("Benson");
            Assert.AreEqual(true, c1.isDead(0));
        }

        [TestMethod]
        public void levelUpCharacterTest()
        {
            Character c1 = new Character("Benson");
            Assert.AreEqual(true, c1.didLevelUp(150));
        }

        [TestMethod]
        public void displayStatsTest()
        {
            Character c1 = new Character("Benson");
            c1.Str = 10;
            c1.Dex = 4;
            c1.Speed = 14;
            c1.Health = 10;

            Monster m1 = new Monster("sunday Slime");
            m1.Str = 10;
            m1.Dex = 4;
            m1.Speed = 14;
            m1.Health = 10;
            Assert.AreEqual(c1.Str,m1.Str);
            Assert.AreEqual(c1.Dex, m1.Dex);
            Assert.AreEqual(c1.Speed, m1.Speed);
            Assert.AreEqual(c1.Health, m1.Health);
        }



        
    }
}
