using Microsoft.VisualStudio.TestTools.UnitTesting;
using StockManagerDB;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dhs = StockManagerDB.DataHolderSingleton;

namespace StockManagerDB.Tests
{
    [TestClass()]
    public class PartUtilsTests
    {
        /// <summary>
        /// Delete the file once disposed
        /// </summary>
        private class FileClass : IDisposable
        {
            public const bool DELETE_FILE_ON_EXIT = true;

            public string path;

            public FileClass(int index)
            {
                path = GetFile(index);
            }

            ~FileClass()
            {
                if (DELETE_FILE_ON_EXIT)
                    Dispose();
            }

            public static implicit operator string(FileClass x) => x.path;

            public void Dispose()
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
                if (File.Exists(path + ".bak"))
                {
                    File.Delete(path + ".bak");
                }
            }

            private string GetFile(int index)
            {
                // Disable history for this test. Every test must call this method
                dhs.__disable_history = true;

                string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "ESN", "Defaults", "ut_pu_" + index + ".smd");
                Console.WriteLine($"Path is : '{path}'");
                if (File.Exists(path))
                    File.Delete(path);
                return path;
            }
        }

        private dhs d => dhs.Instance;

        [TestMethod()]
        public void GetActualOrderQuantityTest()
        {
            FileClass f = new FileClass(1);
            dhs.LoadNew(f);
            d.Load();

            Assert.IsNotNull(d);

            Part p = new Part()
            {
                MPN = "p1",
                Stock = 20,
                LowStock = 10,
            };
            Material m = new Material()
            {
                MPN = "p1",
                Quantity = 15,
            };
            d.Parts.Add(p.MPN, p);

            Assert.AreEqual(1, d.Parts.Count);

            float q = PartUtils.GetActualOrderQuantity(m, false, false, false);
            Assert.AreEqual(15, q);

            q = PartUtils.GetActualOrderQuantity(m, true, false, false);
            Assert.AreEqual(0, q);

            q = PartUtils.GetActualOrderQuantity(m, true, true, false);
            Assert.AreEqual(5, q);

            q = PartUtils.GetActualOrderQuantity(m, true, true, true);
            Assert.AreEqual(5, q);

            q = PartUtils.GetActualOrderQuantity(m, true, false, true);
            Assert.AreEqual(0, q);

            q = PartUtils.GetActualOrderQuantity(m, false, true, false);
            Assert.AreEqual(15, q);

            q = PartUtils.GetActualOrderQuantity(m, false, false, true);
            Assert.AreEqual(15, q);

            q = PartUtils.GetActualOrderQuantity(m, false, true, true);
            Assert.AreEqual(15, q);
        }
    }
}