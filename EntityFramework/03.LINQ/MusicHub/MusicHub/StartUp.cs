namespace MusicHub
{
    using System;
    using System.Linq;
    using Data;
    using Initializer;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            MusicHubDbContext context = 
                new MusicHubDbContext();

            DbInitializer.ResetDatabase(context);

            var result = ExportAlbumsInfo(context, 9);

            Console.WriteLine(result);
        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            var albumInfo = context.Producers
                                    .FirstOrDefault(x => x.Id == producerId)
                                    .Albums
                                    .Select(x => new
                                    {
                                        AlbumName = x.Name,
                                        ReleaseDate = x.ReleaseDate,
                                        ProducerName = x.Producer.Name,
                                        Song = x.Songs.Select(s => new
                                        {
                                            SongName = s.Name,
                                            Price = s.Price,
                                            Writer = s.Writer.Name
                                        }),
                                        AlbumPrice = x.Price
                                    });
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            throw new NotImplementedException();
        }
    }
}
