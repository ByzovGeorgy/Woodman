using System;
using ConsoleApplication1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ForestTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void MoveInhabitant()
        {
            Inhabitant inh = new Inhabitant("inh", 2);
            Forest woodman = new Forest("go.txt");
            woodman.CreateInhabitant(inh, new Vector(1, 2));
            Assert.AreEqual(woodman.MoveInhabitant(inh, new Up()), false);
            Assert.AreEqual(woodman.MoveInhabitant(inh, new Left()), true);
            Assert.AreEqual(woodman.MoveInhabitant(inh, new Left()), false);
            Assert.AreEqual(woodman.MoveInhabitant(inh, new Right()), true);
            Assert.AreEqual(woodman.MoveInhabitant(inh, new Right()), true);
            Assert.AreEqual(woodman.MoveInhabitant(inh, new Right()), false);
            Assert.AreEqual(woodman.MoveInhabitant(inh, new Left()), true);
            Assert.AreEqual(woodman.MoveInhabitant(inh, new Down()), true);
            Assert.AreEqual(woodman.MoveInhabitant(inh, new Down()), false);
        }

        [TestMethod]
        public void MoveInBolders()
        {
            Inhabitant inh = new Inhabitant("inh", 2);
            Forest woodman = new Forest("back.txt");
            woodman.CreateInhabitant(inh, new Vector(0, 1));
            Assert.AreEqual(woodman.MoveInhabitant(inh, new Right()), true);
            Assert.AreEqual(woodman.MoveInhabitant(inh, new Right()), false);
        }

        [TestMethod]
        public void MoveInInhabitant()
        {
            Inhabitant inh = new Inhabitant("inh", 2);
            Inhabitant inh1 = new Inhabitant("inh", 2);
            Forest woodman = new Forest("back.txt");
            woodman.CreateInhabitant(inh, new Vector(0, 1));
            woodman.CreateInhabitant(inh1, new Vector(0, 2));
            Assert.AreEqual(woodman.MoveInhabitant(inh, new Right()), false);
            Assert.AreEqual(woodman.MoveInhabitant(inh1, new Right()), false);
        }

        [TestMethod]
        public void CreateInInhabitant()
        {
            Inhabitant inh = new Inhabitant("inh", 2);
            Inhabitant inh1 = new Inhabitant("inh", 2);
            Forest woodman = new Forest("back.txt");
            woodman.CreateInhabitant(inh, new Vector(0, 1));
            bool flag = false;
            try
            {
                woodman.CreateInhabitant(inh1, new Vector(0, 1));
            }
            catch (Exception ex)
            {
                flag = true;
                Assert.IsTrue(true);
            }
            finally
            {
                if (!flag)
                    Assert.IsTrue(false);
            }
        }
    }
}
