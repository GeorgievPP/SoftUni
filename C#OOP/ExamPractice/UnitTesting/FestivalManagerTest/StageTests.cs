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
        private Performer performer;
        private Stage stage;
        private Song song;

        [SetUp]
        public void SetUp()
        {
            performer = new Performer("Pesho", "Goshov", 19);
            stage = new Stage();
            song = new Song("Vetrove", new TimeSpan(0, 3, 30));
        }


        [Test]
        public void TestConstructor()
        {
            var stage1 = new Stage();

            Assert.AreEqual(0, stage1.Performers.Count);
        }


        [Test]
        public void Test_AddPerformer_WithInvalidParameters()
        {
            var invalidPerformer = new Performer("Niki", "Nikov", 16);


            var ex = Assert.Throws<ArgumentException>(() =>
            {
                stage.AddPerformer(invalidPerformer);
            }
            );

            Assert.AreEqual("You can only add performers that are at least 18.", ex.Message);
        }

        [Test]
        public void Test_AddPerformer()
        {
            stage.AddPerformer(performer);

            int count = 1;

            Assert.AreEqual(count, stage.Performers.Count);
        }

        [Test]
        public void Test_AddSong_WithInvalidParameters()
        {
            var invalidSong = new Song("Panairi", new TimeSpan(0, 0, 30));


            var ex = Assert.Throws<ArgumentException>(() =>
            {
                stage.AddSong(invalidSong);
            }
            );

            Assert.AreEqual("You can only add songs that are longer than 1 minute.", ex.Message);
        }

        [Test]
        public void Test_AddSong()
        {
            stage.AddSong(song);//?

        }

        [Test]
        public void Test_AddSongToPerformer()
        {
            stage.AddPerformer(performer);
            stage.AddSong(song);

            var message = stage.AddSongToPerformer(song.Name, performer.FullName);

            Assert.AreEqual($"{song} will be performed by {performer}", message);
        }

        [Test]
        public void Test_Play()
        {
            var performer2 = new Performer("Pepi", "Mekicov", 30);

            stage.AddPerformer(performer);
            stage.AddPerformer(performer2);

            var song2 = new Song("Burni Noshti", new TimeSpan(0, 2, 30));

            stage.AddSong(song);
            stage.AddSong(song2);

            stage.AddSongToPerformer(song.Name, performer.FullName);
            stage.AddSongToPerformer(song2.Name, performer2.FullName);

            var message = stage.Play();

            Assert.AreEqual("2 performers played 2 songs", message);

        }

        [Test]
        public void Test_GetPerformer_WithInvalidParameters()
        {
            var invalidPerformer = new Performer("Niki", "Nikov", 16);

            stage.AddPerformer(performer);
            stage.AddSong(song);


            var ex = Assert.Throws<ArgumentException>(() =>
            {
                stage.AddSongToPerformer(song.Name, invalidPerformer.FullName);
            }
             );

            Assert.AreEqual("There is no performer with this name.", ex.Message);
        }


        [Test]
        public void Test_GetSong_WithInvalidParameters()
        {
            var invalidSong = new Song("Panairi", new TimeSpan(0, 0, 30));

            stage.AddPerformer(performer);
            stage.AddSong(song);


            var ex = Assert.Throws<ArgumentException>(() =>
            {
                stage.AddSongToPerformer(invalidSong.Name, performer.FullName);
            }
             );

            Assert.AreEqual("There is no song with this name.", ex.Message);
        }

        [Test]
        public void Test_ValidateNullValueSong()
        {
            stage.AddPerformer(performer);

            var ex = Assert.Throws<ArgumentNullException>(() =>
            {
                stage.AddSong(null);
            }
             );

            Assert.AreEqual("Can not be null! (Parameter 'song')", ex.Message);
        }

        [Test]
        public void Test_ValidateNullValuePerformer()
        {
            stage.AddSong(song);

            var ex = Assert.Throws<ArgumentNullException>(() =>
            {
                stage.AddPerformer(null);
            }
             );

            Assert.AreEqual("Can not be null! (Parameter 'performer')", ex.Message);
        }

    }
}