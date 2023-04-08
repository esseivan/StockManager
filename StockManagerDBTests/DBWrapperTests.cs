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
        public void LoadDatabaseListTest()
        {
            string filename = "myDB2.sqlite";
            if (File.Exists(filename))
                File.Delete(filename);
            Assert.IsTrue(!File.Exists(filename));

            DBWrapper dbw = new DBWrapper(filename);
            dbw.CreateDatabase(createTemplatePart: true);
            Assert.IsTrue(File.Exists(filename));

            var parts = dbw.LoadDatabaseList();

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

                var parts = dbw.LoadDatabaseList();

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
                var parts = dbw.LoadDatabaseList();

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

                var parts = dbw.LoadDatabaseList();

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
                var parts = dbw.LoadDatabaseList();

                Assert.IsNotNull(parts);
                Assert.AreEqual(1, parts.Count);
                Assert.AreEqual("Template", parts[0].MPN);

                Assert.AreEqual(lastValStock, parts[0].Stock);
                Assert.AreEqual(lastValPrice, parts[0].Price);
            }

            File.Delete(filename);
            Assert.IsTrue(!File.Exists(filename));
        }

        [TestMethod()]
        public void RenamePartTest()
        {
            string filename = "myDB5.sqlite";
            if (File.Exists(filename))
                File.Delete(filename);
            Assert.IsTrue(!File.Exists(filename));

            string lastMPN;
            using (DBWrapper dbw = new DBWrapper(filename))
            {
                dbw.CreateDatabase(createTemplatePart: true);
                Assert.IsTrue(File.Exists(filename));

                var parts = dbw.LoadDatabaseList();

                Assert.IsNotNull(parts);
                Assert.AreEqual(1, parts.Count);
                Assert.AreEqual("Template", parts[0].MPN);

                lastMPN = "CustomPart";
                dbw.RenamePart(parts[0].MPN, lastMPN);
            }

            using (DBWrapper dbw = new DBWrapper(filename))
            {
                var parts = dbw.LoadDatabaseList();

                Assert.IsNotNull(parts);
                Assert.AreEqual(1, parts.Count);
                Assert.AreEqual(lastMPN, parts[0].MPN);
            }

            File.Delete(filename);
            Assert.IsTrue(!File.Exists(filename));
        }

        [TestMethod()]
        public void AddPartTest()
        {
            string filename = "myDB6.sqlite";
            if (File.Exists(filename))
                File.Delete(filename);
            Assert.IsTrue(!File.Exists(filename));

            PartClass myNewPart = new PartClass()
            {
                MPN = "MyCustomPart1",
                Stock = 17.77f,
            };

            using (DBWrapper dbw = new DBWrapper(filename))
            {
                dbw.CreateDatabase(createTemplatePart: false);
                Assert.IsTrue(File.Exists(filename));

                var parts = dbw.LoadDatabaseList();

                Assert.IsNotNull(parts);
                Assert.AreEqual(0, parts.Count);

                dbw.AddPart(myNewPart);
            }

            using (DBWrapper dbw = new DBWrapper(filename))
            {
                var parts = dbw.LoadDatabaseList();

                Assert.IsNotNull(parts);
                Assert.AreEqual(1, parts.Count);
                Assert.AreEqual(myNewPart.MPN, parts[0].MPN);
                Assert.AreEqual(myNewPart.Stock, parts[0].Stock);
            }

            File.Delete(filename);
            Assert.IsTrue(!File.Exists(filename));
        }

        [TestMethod()]
        public void RemovePartTest()
        {
            string filename = "myDB7.sqlite";
            if (File.Exists(filename))
                File.Delete(filename);
            Assert.IsTrue(!File.Exists(filename));

            using (DBWrapper dbw = new DBWrapper(filename))
            {
                dbw.CreateDatabase(createTemplatePart: true);
                Assert.IsTrue(File.Exists(filename));

                var parts = dbw.LoadDatabaseList();

                Assert.IsNotNull(parts);
                Assert.AreEqual(1, parts.Count);
                Assert.AreEqual("Template", parts[0].MPN);

                dbw.RemovePart(parts[0].MPN);
            }

            using (DBWrapper dbw = new DBWrapper(filename))
            {
                var parts = dbw.LoadDatabaseList();

                Assert.IsNotNull(parts);
                Assert.AreEqual(0, parts.Count);
            }

            File.Delete(filename);
            Assert.IsTrue(!File.Exists(filename));
        }

        [TestMethod()]
        public void RemovePartTest2()
        {
            string filename = "myDB7.sqlite";
            if (File.Exists(filename))
                File.Delete(filename);
            Assert.IsTrue(!File.Exists(filename));

            using (DBWrapper dbw = new DBWrapper(filename))
            {
                dbw.CreateDatabase(createTemplatePart: true);
                Assert.IsTrue(File.Exists(filename));

                var parts = dbw.LoadDatabaseList();

                Assert.IsNotNull(parts);
                Assert.AreEqual(1, parts.Count);
                Assert.AreEqual("Template", parts[0].MPN);

                dbw.RemovePart(parts[0]);
            }

            using (DBWrapper dbw = new DBWrapper(filename))
            {
                var parts = dbw.LoadDatabaseList();

                Assert.IsNotNull(parts);
                Assert.AreEqual(0, parts.Count);
            }

            File.Delete(filename);
            Assert.IsTrue(!File.Exists(filename));
        }
    }
}