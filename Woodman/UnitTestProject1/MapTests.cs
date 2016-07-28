using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApplication1;

namespace UnitTestProject1
{
    [TestClass]
    public class MapTests
    {
        [TestMethod]
        public void FileNotFound()
        {
            bool flag=false;
            try
            {
                MapLoader.Load("dqwd");
            }
            catch (FileNotFoundException ex)
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

        [TestMethod]
        public void LoadNormalMap()
        {
            MapLoader.Load("2.txt");
            CheckMap();
                                     
        }
         [TestMethod]
        public void LoadBadMap()
         {
             MapLoader.Load("3.txt");
             CheckMap();
         }
         [TestMethod]
         public void LoadVoidMap()
         {
             bool flag = false;
             try
             {
                 MapLoader.Load("4.txt");
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

        private static void CheckMap()
        {
            List<List<Texture>> map = new List<List<Texture>>
            {
                new List<Texture>() {new Wood(), new Pathway(), new Wood(), new Wood()},
                new List<Texture>() {new Wood(), new Life(), new Trap(), new Pathway()},
                new List<Texture>() {new Wood(), new Wood(), new Wood(), new Wood()}
            };
            for (int i = 0; i < map.Count; i++)
            {
                for (int j = 0; j < map[i].Count; j++)
                {
                    Assert.IsInstanceOfType(map[i][j], MapLoader.Map[i][j].GetType());
                }
            }
        }
    }
}
