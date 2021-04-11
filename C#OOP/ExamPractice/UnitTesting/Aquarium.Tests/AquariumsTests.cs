namespace Aquariums.Tests
{
    using NUnit.Framework;
    using System;

    public class AquariumsTests
    {
        private Aquarium aquarium;
        private string nameOfAquarium = "Varna";
        private int capacity = 7;

        [SetUp]
        public void Setup()
        {
            this.aquarium = new Aquarium(nameOfAquarium, capacity);
        }

        [Test]
        public void TestAquariumConstructor()
        {
            Assert.AreEqual(this.nameOfAquarium, this.aquarium.Name);

            Assert.AreEqual(this.capacity, this.aquarium.Capacity);
        }

        [Test]
        public void TestAquariumName()
        {
            Aquarium aquarium = new Aquarium("Sofia", 10);

            Assert.AreEqual(aquarium.Name, "Sofia");
        }

        [Test]
        public void TestAquariumNameThrowNullException()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                Aquarium aquarium = new Aquarium(null, 10);
            });

        }

        [Test]
        public void TestNameEmptyException()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                Aquarium aquarium = new Aquarium(String.Empty, 10);
            });

           
        }

        [Test]
        public void TestCapacityException()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Aquarium aquarium = new Aquarium("Sofia", -1);
            }, "Invalid aquarium capacity!");


        }

        [Test]
        public void TestCapacityWork()
        {
            Aquarium aquarium = new Aquarium("Plovdiv", 10);

            Assert.AreEqual(aquarium.Capacity, 10);
        }

       
        [Test]
        public void TestFishCountWorks()
        {
            Aquarium aquarium = new Aquarium("Sofia", 10);
            Fish fish = new Fish("Pesho");

            aquarium.Add(fish);

            Assert.AreEqual(aquarium.Count, 1);
        }

        [Test]
        public void TestAquariumAddsWorks()
        {
            Aquarium aquarium = new Aquarium("Sofia", 3);

            Fish fish = new Fish("Pesho");
            Fish fish1 = new Fish("Gosho");
            Fish fish2 = new Fish("Misho");

            aquarium.Add(fish);
            aquarium.Add(fish1);
            aquarium.Add(fish2);

            Assert.AreEqual(aquarium.Count, 3);
            Assert.That(aquarium.Count, Is.EqualTo(3));
        }

        [Test]
        public void TestFishCapacityException()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                Fish fish = new Fish("Pesho");
                Fish fish1 = new Fish("Gosho");
                Aquarium aquarium = new Aquarium("Sofia", 1);
                aquarium.Add(fish);
                aquarium.Add(fish1);
            }, "Aquarium is full!");

        }


        [Test]
        public void TestRemoveFishException()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {

                Fish fish = new Fish("Pesho");
                Fish fish2 = new Fish("Gosho");
                Fish fish3 = new Fish("Misho");

                Aquarium aquarium = new Aquarium("Sofia", 2);

                aquarium.Add(fish);
                aquarium.Add(fish2);
                aquarium.RemoveFish("Misho");
            }, $"Fish with the name Misho doesn't exist!");

        }


        [Test]
        public void TestSellFishException()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {

                Fish fish = new Fish("Pesho");
                Fish fish2 = new Fish("Gosho");
                Fish fish3 = new Fish("Misho");

                Aquarium aquarium = new Aquarium("Sofia", 2);
                aquarium.Add(fish);
                aquarium.Add(fish2);
                aquarium.SellFish("Misho");
            }, $"Fish with the name Misho doesn't exist!");

        }

        [Test]
        public void TestSellFish()
        {
            Fish fish = new Fish("Pesho");
            Fish fish2 = new Fish("Pesho2");
            Fish fish3 = new Fish("Pesho3");

            Aquarium aquarium = new Aquarium("Aqva", 3);

            aquarium.Add(fish);
            aquarium.Add(fish2);
            aquarium.Add(fish3);

            Fish soldFish = aquarium.SellFish("Pesho3");

            Assert.AreEqual(soldFish.Available, false);

        }

        [Test]
        public void TestReport()
        {
            Fish fish = new Fish("Pesho");
            Fish fish2 = new Fish("Pesho2");
            Fish fish3 = new Fish("Pesho3");

            Aquarium aquarium = new Aquarium("Aqva", 3);

            aquarium.Add(fish);
            aquarium.Add(fish2);
            aquarium.Add(fish3);

            string report = aquarium.Report();

            Assert.AreEqual(report, $"Fish available at { aquarium.Name}: Pesho, Pesho2, Pesho3");

        }

        [Test]
        public void TestRemoveFish()
        {
            Fish fish = new Fish("Pesho");
            Fish fish2 = new Fish("Gosho");
            Fish fish3 = new Fish("Misho");

            Aquarium aquarium = new Aquarium("Sofia", 3);
            aquarium.Add(fish);

            aquarium.Add(fish2);
            aquarium.Add(fish3);
            aquarium.RemoveFish("Misho");

            Assert.AreEqual(aquarium.Count, 2);

            Assert.That(aquarium.Count, Is.EqualTo(2));

        }
    }
}
