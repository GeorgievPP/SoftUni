using System;
using System.Linq;

namespace P03.ExtractFile
{
    class ExtractFile
    {
        static void Main(string[] args)
        {
            string path = Console.ReadLine();

            string[] pathArgs = path
                .Split('\\', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string[] fileInfo = pathArgs
                .Last()
                .Split('.', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string[] fileNameArgs = fileInfo
                .Take(fileInfo.Length - 1)
                .ToArray();

            string fileName = string.Join(".", fileNameArgs);

            string fileExtension = fileInfo.Last();

            Console.WriteLine($"File name: {fileName}");

            Console.WriteLine($"File extension: {fileExtension}");

        }
    }
}
