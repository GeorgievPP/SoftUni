// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to Festival Manager (entities/controllers/etc)
// Test ONLY the Stage class. 
namespace FestivalManager.Tests
{
   // using FestivalManager.Entities;
    using NUnit.Framework;
    using System;


    [TestFixture]
    public class StageTests
    {
        private Stage stage;
        private Performer performer;
        private Song song;
        private TimeSpan duration = new TimeSpan(0, 2, 30);

        [SetUp]
        public void SetUp()
        {
            this.stage = new Stage();
            this.performer = new Performer("Pesho", "Peshov", 20);
            this.song = new Song("SongName", duration);
        }

        [Test]

        public void TestSongConstructorName()
        {
            string expectedName = this.song.Name;
            string actualName = this.song.Name;

            Assert.AreEqual(expectedName, actualName);
        }

        [Test]
        public void TestSongConstructorDuration()
        {
            TimeSpan expectedResult = this.song.Duration;
            TimeSpan actualResult = this.song.Duration;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void TestPerformanceConstructor()
        {
            string expectedFullName = "Pesho Peshov";
            int expectedAge = 20;
            string actualFullName = this.performer.FullName;
            int actualAge = this.performer.Age;


            Assert.AreEqual(expectedFullName, actualFullName);
            Assert.AreEqual(expectedAge, actualAge);
        }

        [Test]
        public void TestStageConstructor()
        {
            int expectedCount = 0;
            int actualCount = this.stage.Performers.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void TestAddPerformerWorks()
        {
            int expectedCount = 1;

            this.stage.AddPerformer(this.performer);
            int actualCount = this.stage.Performers.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void TestAddPerformerShouldThrowArgNullException()
        {
            this.performer = null;

            Assert.Throws<ArgumentNullException>(() =>
            {
                this.stage.AddPerformer(performer);
            });
        }

        [Test]
        public void TestAddPerformerShouldThrowArgumentException()
        {
            this.performer = new Performer("Gosho", "Goshev", 17);

            Assert.Throws<ArgumentException>(() =>
            {
                this.stage.AddPerformer(performer);
            });
        }

        [Test]
        public void TestAddSongShouldThrowNullException()
        {
            this.song = null;

            Assert.Throws<ArgumentNullException>(() =>
            {
                this.stage.AddSong(song);
            });
        }

        [Test]

        public void TestAddSongShouldThrowExceptionForDuration()
        {
            this.song = new Song("newName", new TimeSpan(0, 0, 30));

            Assert.Throws<ArgumentException>(() =>
            {
                this.stage.AddSong(song);
            });
        }

        [Test]
        public void TestAddSongToPerformerShouldWork()
        {
            int expectedCount = 1;

            this.song = new Song("newName", new TimeSpan(0, 1, 30));
            this.stage.AddSong(this.song);
            this.stage.AddPerformer(this.performer);
            this.stage.AddSongToPerformer(this.song.Name, this.performer.FullName);

            Assert.AreEqual(expectedCount, this.performer.SongList.Count);
        }

        [Test]
        public void TestGetPerformerShouldThrowException()
        {
            string wrongName = "Mitko Pavlov";

            this.song = new Song("newName", new TimeSpan(0, 1, 30));
            this.stage.AddSong(this.song);
            this.stage.AddPerformer(this.performer);
            this.stage.AddSongToPerformer(this.song.Name, this.performer.FullName);

            Assert.Throws<ArgumentException>(() =>
            {
                this.stage.AddSongToPerformer(this.song.Name, wrongName);
            });
        }

        [Test]
        public void TestGetSongShouldThrowException()
        {
            string wrongName = "Mitko Pavlov";

            this.song = new Song("newName", new TimeSpan(0, 1, 30));
            this.stage.AddSong(this.song);
            this.stage.AddPerformer(this.performer);
            this.stage.AddSongToPerformer(this.song.Name, this.performer.FullName);

            Assert.Throws<ArgumentException>(() =>
            {
                this.stage.AddSongToPerformer(wrongName, this.performer.FullName);
            });
        }

        [Test]
        public void TestPlayWorksCorrectly()
        {
            Song songFirst = new Song("One", new TimeSpan(0, 2, 46));
            Song songSecond = new Song("Two", new TimeSpan(0, 2, 10));

            this.stage.AddSong(songFirst);
            this.stage.AddSong(songSecond);

            this.stage.AddPerformer(this.performer);

            this.stage.AddSongToPerformer(songFirst.Name, this.performer.FullName);
            this.stage.AddSongToPerformer(songSecond.Name, this.performer.FullName);

            string expectedResult = "1 performers played 2 songs";
            string actualResult = this.stage.Play();

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void StageIsNotNull()
        {
            Assert.IsNotNull(stage);
        }     

        [Test]

        public void TestAddSong()
        {
           
            this.song = new Song("ko", new TimeSpan(0, 2, 30));

            this.stage.AddSong(this.song);
        }

        [Test]
        public void TestAddSongToPerformerShouldWorkTwoReturnString()
        {
            this.song = new Song("newName", new TimeSpan(0, 1, 30));
            this.stage.AddSong(this.song);
            this.stage.AddPerformer(this.performer);
            this.stage.AddSongToPerformer(this.song.Name, this.performer.FullName);

            string expectedResult = $"{this.song.Name} will be performed by {this.performer.FullName}";
            string actualRsult = $"{this.song.Name} will be performed by {this.performer.FullName}";

            Assert.AreEqual(expectedResult, actualRsult);
        }

        [Test]
        public void TestAddSongToPerformerShouldWorkTwoReturnString2()
        {
            this.song = new Song("newName", new TimeSpan(0, 1, 30));
            this.stage.AddSong(this.song);
            this.stage.AddPerformer(this.performer);
            this.stage.AddSongToPerformer(this.song.Name, this.performer.FullName);

            string expectedResult = $"{this.song} will be performed by {this.performer}";
            string actualRsult = $"{this.song} will be performed by {this.performer}";

            Assert.AreEqual(expectedResult, actualRsult);
        }
    }
}