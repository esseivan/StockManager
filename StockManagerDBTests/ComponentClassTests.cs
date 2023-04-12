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
    public class ComponentClassTests
    {
        private string GetFile(int index)
        {
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "ESN", "Defaults", "utcct_" + index + ".smd");
            Console.WriteLine($"Path is : '{path}'");
            if (File.Exists(path))
                File.Delete(path);
            return path;
        }

        [TestMethod()]
        public void ComponentClassTest()
        {
            ComponentClass c = new ComponentClass();

            // MPN
            c.Parameters[ComponentClass.Parameter.MPN] = "MPN1";
            Assert.AreEqual("MPN1", c.MPN);
            c.MPN = "MPN2";
            Assert.AreEqual("MPN2", c.Parameters[ComponentClass.Parameter.MPN]);

            // Parent
            c.Parameters[ComponentClass.Parameter.Parent] = "Parent1";
            Assert.AreEqual("Parent1", c.Parent);
            c.Parent = "Parent2";
            Assert.AreEqual("Parent2", c.Parameters[ComponentClass.Parameter.Parent]);

            // Quantity
            c.Parameters[ComponentClass.Parameter.Quantity] = "Quantity1";
            Assert.AreEqual("Quantity1", c.QuantityStr);
            Assert.AreEqual(0, c.Quantity);
            c.QuantityStr = "Quantity2";
            Assert.AreEqual("Quantity2", c.Parameters[ComponentClass.Parameter.Quantity]);
            Assert.AreEqual(0, c.Quantity);
            c.Quantity = 5.00f;
            Assert.AreEqual((5.0f).ToString(), c.Parameters[ComponentClass.Parameter.Quantity]);

            // Reference
            c.Parameters[ComponentClass.Parameter.Reference] = "Reference1";
            Assert.AreEqual("Reference1", c.Reference);
            c.Reference = "Reference2";
            Assert.AreEqual("Reference2", c.Parameters[ComponentClass.Parameter.Reference]);

        }

        [TestMethod()]
        public void CloneTest()
        {
            ComponentClass c1 = new ComponentClass()
            {
                MPN = "MPN1",
                Parent = "Project1",
                Reference = "Rx",
                Quantity = 9.99f,
            };

            ComponentClass c2 = c1.Clone() as ComponentClass;

            Assert.IsNotNull(c2);
            Assert.AreEqual(c1.MPN, c2.MPN);
            Assert.AreEqual(c1.Parent, c2.Parent);
            Assert.AreEqual(c1.Reference, c2.Reference);
            Assert.AreEqual(c1.Quantity, c2.Quantity);

            c1.MPN = "new1";
            c1.Parent = "new2";
            c1.Reference = "new3";
            c1.Quantity = -5.55f;

            Assert.AreEqual("MPN1", c2.MPN);
            Assert.AreEqual("Project1", c2.Parent);
            Assert.AreEqual("Rx", c2.Reference);
            Assert.AreEqual(9.99f, c2.Quantity);
        }

        [TestMethod()]
        public void CloneTest_Undefined()
        {
            ComponentClass c1 = new ComponentClass()
            {
                MPN = null,
                Parent = null,
                Reference = null,
                QuantityStr = null,
            };
            c1.Parameters[ComponentClass.Parameter.UNDEFINED] = "UNDEFINED PARAM";
            ComponentClass c2 = c1.Clone() as ComponentClass;

            Assert.IsNotNull(c2);
            Assert.AreEqual(c1.MPN, c2.MPN);
            Assert.AreEqual(c1.Parent, c2.Parent);
            Assert.AreEqual(c1.Reference, c2.Reference);
            Assert.AreEqual(c1.Quantity, c2.Quantity);

        }

        [TestMethod()]
        public void CloneTest_Empty()
        {
            ComponentClass c1 = new ComponentClass();


            ComponentClass c2 = c1.Clone() as ComponentClass;

            Assert.IsNotNull(c2);
            Assert.AreEqual(c1.MPN, c2.MPN);
            Assert.AreEqual(c1.Parent, c2.Parent);
            Assert.AreEqual(c1.Reference, c2.Reference);
            Assert.AreEqual(c1.Quantity, c2.Quantity);

        }

        [TestMethod()]
        public void CloneTest_CompareMPN()
        {
            ComponentClass c1 = new ComponentClass()
            {
                MPN = "M1",
            };
            ComponentClass c2 = new ComponentClass()
            {
                MPN = "M2",
            };
            ComponentClass c3 = new ComponentClass()
            {
                MPN = "A0",
            };

            List<ComponentClass> components = new List<ComponentClass>()
            {
                c1, c2, c3
            };
            components.Sort(new ComponentClass.CompareMPN());

            Assert.AreEqual("A0", components[0].MPN);
            Assert.AreEqual("M1", components[1].MPN);
            Assert.AreEqual("M2", components[2].MPN);
        }

        [TestMethod()]
        public void PartLinkTest_null()
        {
            ComponentClass c1 = new ComponentClass()
            {
                MPN = "M1",
            };

            Assert.IsNull(c1.PartLink);
        }

        [TestMethod()]
        public void PartLinkTest_notFound()
        {
            string f = GetFile(1);
            DataHolderSingleton.LoadNew(f);

            ComponentClass c1 = new ComponentClass()
            {
                MPN = "M1",
            };

            Part p = new Part()
            {
                MPN = "M2",
                Stock = 5,
            };
            DataHolderSingleton.Instance.Parts.Add(p.MPN, p);

            Assert.IsNull(c1.PartLink);
        }

        [TestMethod()]
        public void PartLinkTest()
        {
            string f = GetFile(1);
            DataHolderSingleton.LoadNew(f);

            ComponentClass c1 = new ComponentClass()
            {
                MPN = "M1",
            };

            Part p = new Part()
            {
                MPN = "M1",
                Stock = 5,
            };
            DataHolderSingleton.Instance.Parts.Add(p.MPN, p);

            Assert.AreEqual(p, c1.PartLink);
        }
    }
}