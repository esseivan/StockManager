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
            string filename = "myDB.sqlite";
            if (File.Exists(filename))
                File.Delete(filename);
            Assert.IsTrue(!File.Exists(filename));

            DBWrapper dbw = new DBWrapper(filename);

            dbw.CreateDatabase();

            Assert.IsTrue(File.Exists(filename));
        }
    }
}