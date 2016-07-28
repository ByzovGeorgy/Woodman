using System;
using ConsoleApplication1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestAi
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Inhabitant Thronduil = new Inhabitant("Thronduil", 8);
            Forest woodman = new Forest("1.txt", new Vector(1, 1));
            woodman.CreateInhabitant(Thronduil, new Vector(1, 3));
            Ai bot = new Ai(Thronduil, woodman);
            Assert.AreEqual(bot.FindWay(),true);
        }
        [TestMethod]
        public void TestMethod2()
        {
            Inhabitant Thronduil = new Inhabitant("Thronduil", 8);
            Forest woodman = new Forest("1.txt", new Vector(1, 3));
            woodman.CreateInhabitant(Thronduil, new Vector(1, 1));
            Ai bot = new Ai(Thronduil, woodman);
            Assert.AreEqual(bot.FindWay(), true);
        }
         [TestMethod]
        public void TestMethod3()
        {
            Inhabitant Thronduil = new Inhabitant("Thronduil", 8);
            Forest woodman = new Forest("1.txt", new Vector(6, 3));
            woodman.CreateInhabitant(Thronduil, new Vector(1, 1));
            Ai bot = new Ai(Thronduil, woodman);
            Assert.AreEqual(bot.FindWay(), true);
        }
         [TestMethod]
         public void TestMethod5()
         {
             Inhabitant Thronduil = new Inhabitant("Thronduil", 2);
             Forest woodman = new Forest("1.txt", new Vector(1, 1));
             woodman.CreateInhabitant(Thronduil, new Vector(1, 3));
             Ai bot = new Ai(Thronduil, woodman);
             Assert.AreEqual(bot.FindWay(), false);
         }
    }
}
