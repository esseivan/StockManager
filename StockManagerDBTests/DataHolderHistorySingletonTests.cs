using Microsoft.VisualStudio.TestTools.UnitTesting;
using StockManagerDB;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dhs = StockManagerDB.DataHolderSingleton;
using dhsh = StockManagerDB.DataHolderHistorySingleton;

namespace StockManagerDB.Tests
{
    [TestClass()]
    public class DataHolderHistorySingletonTests
    {
        private string GetFile(int index)
        {
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "ESN", "Defaults", "ut_" + index + ".smd");
            string path2 = path + "h";
            Console.WriteLine($"Path is : '{path}'");
            if (File.Exists(path))
                File.Delete(path);
            if (File.Exists(path2))
                File.Delete(path2);
            return path;
        }

        private dhs d => dhs.Instance;
        private dhsh dh => dhsh.Instance;

        [TestMethod()]
        public void LoadNewTest()
        {
            string f = GetFile(1);
            dhs.LoadNew(f);

            Assert.IsNotNull(dh);
            Assert.AreEqual(0, dh.PartHistory.Count);
        }

        [TestMethod()]
        public void LoadTest()
        {
            string f = GetFile(2);
            dhs.LoadNew(f);
            d.Load();

            Assert.IsNotNull(dh);
            Assert.AreEqual(0, dh.PartHistory.Count);
        }

        [TestMethod()]
        public void AddInsertEventTest()
        {
            string f = GetFile(3);
            dhs.LoadNew(f);

            Part part = new Part()
            {
                MPN = "P1",
                Stock = 0,
                Description = "Desc",
            };

            d.AddPart(part);

            // AddPart doesn't add to history yet
            Assert.AreEqual(0, dh.PartHistory.Count);
        }

        [TestMethod()]
        public void AddDeleteEventTest()
        {
            string f = GetFile(4);
            dhs.LoadNew(f);

            Part part = new Part()
            {
                MPN = "P1",
                Stock = 0,
                Description = "Desc",
            };

            d.AddPart(part);

            Assert.AreEqual(1, d.Parts.Count);

            d.DeletePart("P1");

            Assert.AreEqual(1, dh.PartHistory.Count);

            Part delPart = dh.PartHistory[0];

            Assert.AreEqual(part, delPart);
            Assert.AreEqual("Delete", delPart.Status);
            Assert.AreEqual(0, delPart.Version);
            Assert.IsTrue(delPart.ValidUntil <= DateTime.Now);
            Assert.IsTrue(delPart.ValidFrom <= DateTime.Now);
            Console.WriteLine(delPart.ValidFrom);
            Console.WriteLine(delPart.ValidUntil);
        }

        [TestMethod()]
        public void AddUpdateEventTest()
        {
            string f = GetFile(4);
            dhs.LoadNew(f);

            Part part = new Part()
            {
                MPN = "P1",
                Stock = 0,
                Description = "Desc",
            };

            d.AddPart(part);

            Assert.AreEqual(1, d.Parts.Count);

            d.EditPart("P1", Part.Parameter.Stock, "99");

            Assert.AreEqual(1, dh.PartHistory.Count);

            Part oldPart = dh.PartHistory[0];

            Assert.AreEqual(part, part);
        }
    }
}