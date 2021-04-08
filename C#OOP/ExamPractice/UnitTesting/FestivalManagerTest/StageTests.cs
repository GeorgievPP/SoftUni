// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to Festival Manager (entities/controllers/etc)
// Test ONLY the Stage class. 
namespace FestivalManager.Tests
{
   // using FestivalManager.Entities;
    using NUnit.Framework;
    using System;
    using System.Linq;

    [TestFixture]
	public class StageTests
    {
		[Test]
	    public void TestConstructor()
	    {
			var stage = new Stage();
			var performer = new Performer("Pesho", "Peshov", 18);

			stage.AddPerformer(performer);
		}

		[Test]

		public void TestAddPerformerException()
        {
			var stage = new Stage();
			var performer = new Performer("Pesho", "Peshov", 10);

			Assert.Throws<ArgumentException>(() =>
			{
				stage.AddPerformer(performer);
			});
		}

		[Test]

		public void TestAddSong()
        {
			var stage = new Stage();
			var song = new Song("ko", new TimeSpan(0, 2, 30));

			stage.AddSong(song);
        }

		[Test]

		public void TestAddSongException()
		{
			var stage = new Stage();
			var song = new Song("ko", new TimeSpan(0, 0, 30));

			Assert.Throws<ArgumentException>(() =>
			{
				stage.AddSong(song);
			});
		}


		[Test]

		public void TestAddSongToPerformer()
		{
			var stage = new Stage();
			var song = new Song("ko", new TimeSpan(0, 2, 30));
			var performer = new Performer("Pe", "Pes", 20);

			stage.AddSong(song);
			stage.AddPerformer(performer);

			stage.AddSongToPerformer(song.Name, performer.FullName);
		}

		[Test]

		public void TestPlay()
		{
			var stage = new Stage();
			var song = new Song("ko", new TimeSpan(0, 2, 30));
			var performer = new Performer("Pe", "Pes", 20);

			stage.AddSong(song);
			stage.AddPerformer(performer);

			stage.AddSongToPerformer(song.Name, performer.FullName);

			stage.Play();
		}

		[Test]

		public void TestGetPerfException()
        {
			var stage = new Stage();
			var song = new Song("ko", new TimeSpan(0, 2, 30));
			var performer = new Performer("Pe", "Pes", 20);

			stage.AddSong(song);
			stage.AddPerformer(performer);

			Assert.Throws<ArgumentException>(() =>
			{
				stage.AddSongToPerformer(song.Name, "Pesho");
			});

		}

		[Test]

		public void TestGetSongException()
		{
			var stage = new Stage();
			var song = new Song("ko", new TimeSpan(0, 2, 30));
			var performer = new Performer("Pe", "Pes", 20);

			stage.AddSong(song);
			stage.AddPerformer(performer);

			Assert.Throws<ArgumentException>(() =>
			{
				stage.AddSongToPerformer("Pesho", performer.FullName);
			});

		}

		[Test]
		public void TestValidateSomothing()
		{
			var stage = new Stage();
			
			Assert.Throws<ArgumentNullException>(() =>
			{
				stage.AddPerformer(null);
			});
		}
	}
}