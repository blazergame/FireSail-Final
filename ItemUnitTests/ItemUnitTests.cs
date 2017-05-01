using DandD.Models.Game_Files;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ItemUnitTests
{
    [TestClass]
    public class ItemUnitTests
    {

        [TestMethod]
        public void TestDefaultItemHP()
        {
            Items item = new Items();
            Assert.AreEqual(item.Health, 10);
        }

        [TestMethod]
        public void TestDefaultStr()
        {
            Items item = new Items();
            int str = item.Str;
            if (item.Str >= 1 && item.Str <= 10)
                Assert.AreEqual(item.Str, str);
        }
        [TestMethod]
        public void TestDefaultDex()
        {
            Items item = new Items();
            int dex = item.Dex;
            if (item.Dex >= 1 && item.Dex <= 10)
                Assert.AreEqual(item.Dex, dex);
        }

        [TestMethod]
        public void TestDefaultSpeed()
        {
            Items item = new Items();
            int speed = item.Speed;
            if (item.Speed >= 1 && item.Dex <= 10)
                Assert.AreEqual(item.Speed, speed);
        }

        [TestMethod]
        public void TestCustomItemConstructor()
        {
            string Name = "Sword of Doom";
            int Str = 10;
            int Dex = 10;
            int Speed = 11;
            Items item = new Items(Name, Str, Dex, Speed);
            Assert.AreEqual(item.Speed, Speed);
            Assert.AreEqual(item.Str, Str);
            Assert.AreEqual(item.Dex, Dex);
            Assert.AreEqual(item.Health, 10);
            Assert.AreEqual(item.Name, Name);
        }

        [TestMethod]
        public void TestRandomNameGenerator()
        {
            Items item1 = new Items();
            System.Threading.Thread.Sleep(5000);
            Items item2 = new Items();
            Assert.AreNotEqual(item1.Name, item2.Name);
        }

        [TestMethod]
        public void TestRandomItemGenerator()
        {
            Items item1 = new Items();
            System.Threading.Thread.Sleep(5000);
            Items item2 = new Items();
            Assert.AreNotSame(item1, item2);
        }
    }
}
