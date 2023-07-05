using ESNLib.Tools;
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
    public class DataHolderSingletonTests
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

                string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "ESN", "Defaults", "ut_" + index + ".smd");
                Console.WriteLine($"Path is : '{path}'");
                if (File.Exists(path))
                    File.Delete(path);
                return path;
            }
        }

        private dhs d => dhs.Instance;

        [TestMethod()]
        public void LoadNewTest()
        {
            FileClass f = new FileClass(1);
            dhs.LoadNew(f);

            Assert.IsNotNull(d);
            Assert.AreEqual(0, d.Parts.Count);
            Assert.AreEqual(0, d.Projects.Count);
        }

        [TestMethod()]
        public void LoadFileTest()
        {
            FileClass f = new FileClass(2);
            dhs.LoadNew(f);
            d.Load();

            Assert.IsNotNull(d);
            Assert.AreEqual(0, d.Parts.Count);
            Assert.AreEqual(0, d.Projects.Count);
        }

        [TestMethod()]
        public void CloseFileTest()
        {
            FileClass f = new FileClass(3);
            dhs.LoadNew(f);
            d.Load();

            Assert.IsNotNull(d);
            Assert.AreEqual(0, d.Parts.Count);
            Assert.AreEqual(0, d.Projects.Count);

            d.Close();

            Assert.IsNull(d);
        }

        static int x1 = 0;
        [TestMethod()]
        public void InvokeOnPartListModifiedTest()
        {
            FileClass f = new FileClass(4);
            dhs.LoadNew(f);
            d.Load();

            dhs.OnPartListModified += Dhs_OnPartListModified;
            dhs.OnProjectsListModified += Dhs_OnProjectsListModified;

            d.InvokeOnPartListModified(EventArgs.Empty);
            d.InvokeOnProjectsListModified(EventArgs.Empty);

            Assert.AreEqual(-1, x1);
        }

        private void Dhs_OnProjectsListModified(object sender, EventArgs e)
        {
            x1 -= 2;
        }

        private void Dhs_OnPartListModified(object sender, EventArgs e)
        {
            x1++;
        }

        [TestMethod()]
        public void InvokeOnPartListModifiedTest_notDefined()
        {
            FileClass f = new FileClass(4);
            dhs.LoadNew(f);
            d.Load();

            d.InvokeOnPartListModified(EventArgs.Empty);
            d.InvokeOnProjectsListModified(EventArgs.Empty);

            Assert.IsNotNull(d);
        }
    }
}