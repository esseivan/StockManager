using Microsoft.VisualStudio.TestTools.UnitTesting;
using StockManagerDB;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagerDB.Tests
{
    [TestClass()]
    public class DBWrapperTests
    {
        [TestMethod()]
        public void CreateDatabaseTest()
        {
            string filename = "myDB1.sqlite";
            if (File.Exists(filename))
                File.Delete(filename);
            Assert.IsTrue(!File.Exists(filename));

            DBWrapper dbw = new DBWrapper(filename);

            dbw.CreateDatabase();

            Assert.IsTrue(File.Exists(filename));

            File.Delete(filename);
            Assert.IsTrue(!File.Exists(filename));
        }

        [TestMethod()]
        public void LoadDatabaseTest()
        {
            string filename = "myDB2.sqlite";
            if (File.Exists(filename))
                File.Delete(filename);
            Assert.IsTrue(!File.Exists(filename));

            DBWrapper dbw = new DBWrapper(filename);
            dbw.CreateDatabase(createTemplatePart: true);
            Assert.IsTrue(File.Exists(filename));

            var parts = dbw.LoadDatabase();

            Assert.IsNotNull(parts);
            Assert.AreEqual(1, parts.Count);
            Assert.AreEqual("Template", parts[0].MPN);

            File.Delete(filename);
            Assert.IsTrue(!File.Exists(filename));
        }

        [TestMethod()]
        public void UpdatePartTest_1change()
        {
            string filename = "myDB3.sqlite";
            if (File.Exists(filename))
                File.Delete(filename);
            Assert.IsTrue(!File.Exists(filename));

            float lastVal;
            using (DBWrapper dbw = new DBWrapper(filename))
            {
                dbw.CreateDatabase(createTemplatePart: true);
                Assert.IsTrue(File.Exists(filename));

                var parts = dbw.LoadDatabase();

                Assert.IsNotNull(parts);
                Assert.AreEqual(1, parts.Count);
                Assert.AreEqual("Template", parts[0].MPN);

                float val1 = parts[0].Stock;
                lastVal = val1 + 4;
                parts[0].Stock = lastVal;
                dbw.UpdatePart(parts[0]);
            }

            using (DBWrapper dbw = new DBWrapper(filename))
            {
                var parts = dbw.LoadDatabase();

                Assert.IsNotNull(parts);
                Assert.AreEqual(1, parts.Count);
                Assert.AreEqual("Template", parts[0].MPN);

                float val = parts[0].Stock;

                Assert.AreEqual(lastVal, val);
            }

            File.Delete(filename);
            Assert.IsTrue(!File.Exists(filename));
        }

        [TestMethod()]
        public void UpdatePartTest_2change()
        {
            string filename = "myDB4.sqlite";
            if (File.Exists(filename))
                File.Delete(filename);
            Assert.IsTrue(!File.Exists(filename));

            float lastValStock, lastValPrice;
            using (DBWrapper dbw = new DBWrapper(filename))
            {
                dbw.CreateDatabase(createTemplatePart: true);
                Assert.IsTrue(File.Exists(filename));

                var parts = dbw.LoadDatabase();

                Assert.IsNotNull(parts);
                Assert.AreEqual(1, parts.Count);
                Assert.AreEqual("Template", parts[0].MPN);

                float val1 = parts[0].Stock;
                lastValStock = val1 + 4;
                parts[0].Stock = lastValStock;
                val1 = parts[0].Price;
                lastValPrice = val1 + 99;
                parts[0].Price = lastValPrice;
                dbw.UpdatePart(parts[0]);
            }

            using (DBWrapper dbw = new DBWrapper(filename))
            {
                var parts = dbw.LoadDatabase();

                Assert.IsNotNull(parts);
                Assert.AreEqual(1, parts.Count);
                Assert.AreEqual("Template", parts[0].MPN);

                Assert.AreEqual(lastValStock, parts[0].Stock);
                Assert.AreEqual(lastValPrice, parts[0].Price);
            }

            File.Delete(filename);
            Assert.IsTrue(!File.Exists(filename));
        }
    }
}