using NUnit.Framework;
using System;
//using TheRace;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestConstruct()
        {
            var race = new RaceEntry();
            var car = new UnitCar("BMW", 100, 3000);
            var driver = new UnitDriver("Pesho", car);

            race.AddDriver(driver);

            Assert.AreEqual(1, race.Counter);
        }

        [Test]
        public void TestNullForDriverException()
        {
            var race = new RaceEntry();

            Assert.Throws<InvalidOperationException>(() =>
            {
                race.AddDriver(null);
            });
        }

        [Test] 
        public void TestIfDriverIsTheSameException()
        {
            var race = new RaceEntry();
            var car = new UnitCar("BMW", 100, 3000);
            var driver = new UnitDriver("Pesho", car);

            race.AddDriver(driver);

            Assert.Throws<InvalidOperationException>(() =>
            {
                race.AddDriver(driver);
            });
        }

        [Test]
        public void TestCalculateAverageHorsePowerWorksCorrectly()
        {
            var race = new RaceEntry();

            var car = new UnitCar("BMW", 100, 3000);
            var driver = new UnitDriver("Pesho", car);
            race.AddDriver(driver);

            var car1 = new UnitCar("Lada", 100, 3000);
            var driver1 = new UnitDriver("Gosho", car1);
            race.AddDriver(driver1);

            var car2 = new UnitCar("Audi", 100, 3000);
            var driver2 = new UnitDriver("Miro", car2);
            race.AddDriver(driver2);

            double expectedAvrg = 100;
            double actualAvrg = race.CalculateAverageHorsePower();

            Assert.AreEqual(expectedAvrg, actualAvrg);
        }

        [Test]
        public void TestCalculateAverageHorsePowerException()
        {
            var race = new RaceEntry();
            var car = new UnitCar("BMW", 100, 3000);
            var driver = new UnitDriver("Pesho", car);

            race.AddDriver(driver);

            Assert.Throws<InvalidOperationException>(() =>
            {
                race.CalculateAverageHorsePower();
            });
        }
    }
}