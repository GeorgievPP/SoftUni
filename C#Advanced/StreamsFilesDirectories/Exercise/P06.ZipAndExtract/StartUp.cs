using System.IO.Compression;

namespace P._06.ZipAndExtract
{
    class StartUp
    {
        static void Main(string[] args)
        {
            ZipFile.CreateFromDirectory(@"C:\Users\calev\Desktop\Pic", @"C:\Users\calev\Desktop\newPath\myArchive.zip");

            ZipFile.ExtractToDirectory(@"C:\Users\calev\Desktop\newPath\myArchive.zip", @"C:\Users\calev\Desktop\newDirectory");
        }
    }
}
