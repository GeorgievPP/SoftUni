using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Computers.Tests
{
    public class Tests
    {
        private ComputerManager computers;
        private Computer comp;

        [SetUp]
        public void Setup()
        {
            this.computers = new ComputerManager();
            this.comp = new Computer("msi", "xvc", 2000m);
        }

        [Test]
        public void TestAddComputerWorks()
        {
            int expCount = 1;

            this.computers.AddComputer(comp);
            int actCount = this.computers.Count;

            Assert.AreEqual(expCount, actCount);
        }

        [Test]
        public void TestAddComputerValidateNullValueException()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                this.computers.AddComputer(null);
            });
        }

        [Test]
        public void TestAddComputerArgumentException()
        {
            this.computers.AddComputer(comp);
            Computer newComp = new Computer("msi", "xvc", 2000m);

            Assert.Throws<ArgumentException>(() =>
            {
                this.computers.AddComputer(newComp);
            });
        }


        [Test]
        public void TestGetCompWorks()
        {
            this.computers.AddComputer(comp);

            string manufacter = "msi";
            string model = "xvc";

            var expResult = this.computers.GetComputer(manufacter, model);

            Assert.AreEqual(expResult, this.computers.GetComputer(comp.Manufacturer, comp.Model));

        }


        [Test]
        public void TestGetCompException()
        {
            this.computers.AddComputer(comp);

            string manufacter = "msi";
            string model = "vvc";

            Assert.Throws<ArgumentException>(() =>
            {
                var expResult = this.computers.GetComputer(manufacter, model);
            });
        }

        [Test]
        public void TestRemoveCompWorks()
        {
            this.computers.AddComputer(comp);

            string manufacter = "msi";
            string model = "xvc";

            var expResult = this.computers.GetComputer(manufacter, model);

            Assert.AreEqual(expResult, this.computers.RemoveComputer(comp.Manufacturer, comp.Model));

        }

        [Test]
        public void TestGetCompsByManufacturer()
        {
            this.computers.AddComputer(comp);

            string manufacter = "msi2";
            string model = "xvc2";

            Computer comp2 = new Computer(manufacter, model, 2000m);
            Computer comp3 = new Computer(manufacter, "hds", 3000m);
            Computer comp4 = new Computer("Asus", "rog", 3000m);

            this.computers.AddComputer(comp3);
            this.computers.AddComputer(comp2);
            this.computers.AddComputer(comp4);

            List<Computer> comps = this.computers.Computers.Where(x => x.Manufacturer == manufacter).ToList();

            Assert.AreEqual(comps, this.computers.GetComputersByManufacturer(manufacter));

        }

        [Test]
        public void TestGetComputerValidateNullValueException()
        {
            this.computers.AddComputer(comp);

            Assert.Throws<ArgumentNullException>(() =>
            {
                this.computers.GetComputer(null, "kkr");
            });
        }

        [Test]
        public void TestGetComputerValidateNullValueExceptio2()
        {
            this.computers.AddComputer(comp);

            Assert.Throws<ArgumentNullException>(() =>
            {
                this.computers.GetComputer(comp.Manufacturer, null);
            });
        }

        [Test]
        public void TestGetComputersByManufactorerValidateNullValueExceptio()
        {
            this.computers.AddComputer(comp);

            Assert.Throws<ArgumentNullException>(() =>
            {
                this.computers.GetComputersByManufacturer(null);
            });
        }
    }
}