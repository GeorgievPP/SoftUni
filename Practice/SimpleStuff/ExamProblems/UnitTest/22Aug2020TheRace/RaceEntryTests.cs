using NUnit.Framework;
using System;
using TheRace;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestConstructor()
        {
            var race = new RaceEntry();
            var car = new UnitCar("Audi", 100, 2000);
            var driver = new UnitDriver("Pesho", car);

            race.AddDriver(driver);

            Assert.AreEqual(1, race.Counter);
        }

        [Test]

        public void TestAddDriverNullException()
        {
            var race = new RaceEntry();

            Assert.Throws<InvalidOperationException>(() =>
            {
                race.AddDriver(null);
            });
            
        }

        [Test]

        public void TestAddDriverSameDriverException()
        {
            var race = new RaceEntry();
            var car = new UnitCar("Audi", 100, 2000);
            var driver = new UnitDriver("Pesho", car);
            var car1 = new UnitCar("Audi", 100, 2000);
            var driver1 = new UnitDriver("Pesho", car);

            race.AddDriver(driver);

            Assert.Throws<InvalidOperationException>(() =>
            {
                race.AddDriver(driver1);
            });

        }

        [Test]

        public void TestCalculateAverageHorsePower()
        {
            var race = new RaceEntry();
            var car = new UnitCar("BMW", 100, 2000);
            var driver = new UnitDriver("Pesho", car);

            var car1 = new UnitCar("Mercedes", 100, 2000);
            var driver1 = new UnitDriver("Gosho", car);

            var car2 = new UnitCar("VW", 100, 2000);
            var driver2 = new UnitDriver("Mite", car);

            race.AddDriver(driver);
            race.AddDriver(driver1);
            race.AddDriver(driver2);

            double expectedHorsePow = 100;
            double actualHorsePow = race.CalculateAverageHorsePower();

            Assert.AreEqual(expectedHorsePow, actualHorsePow);
        }
    }
}