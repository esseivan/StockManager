using Microsoft.VisualStudio.TestTools.UnitTesting;
using StockManagerDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagerDB.Tests
{
    [TestClass()]
    public class ListManagerTests
    {
        [TestMethod()]
        public void CreateNewTest()
        {
            string path = ListManager.GetDefaultPath("mylist1", "UnitTest");
            Console.WriteLine(path);
            ListManager lmi = ListManager.CreateNew(path, templateItems: true);

            Assert.AreEqual(1, lmi.Data.Parts.Count);
            Assert.AreEqual(1, lmi.Data.Components.Count);
        }

        [TestMethod()]
        public void CreateNewTest2()
        {
            string path = ListManager.GetDefaultPath("mylist2", "UnitTest");
            Console.WriteLine(path);
            ListManager lmi = ListManager.CreateNew(path, templateItems: false);

            Assert.AreEqual(0, lmi.Data.Parts.Count);
            Assert.AreEqual(0, lmi.Data.Components.Count);
        }

        [TestMethod()]
        public void CreateAndLoadTest()
        {
            string path = ListManager.GetDefaultPath("mylist3", "UnitTest");
            Console.WriteLine(path);
            using (ListManager lmi = ListManager.CreateNew(path, templateItems: true))
            {
                Assert.AreEqual(1, lmi.Data.Parts.Count);
                Assert.AreEqual(1, lmi.Data.Components.Count);
            }

            ListManager lmi2 = new ListManager(path);
            Assert.AreEqual(1, lmi2.Data.Parts.Count);
            Assert.AreEqual(1, lmi2.Data.Components.Count);
        }
    }
}