using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace P05.DirectoryTraversal
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string directoryPath = Directory.GetCurrentDirectory();
            string[] fileNames = Directory.GetFiles(directoryPath);
            Dictionary<string, Dictionary<string, double>> filesDate =
                new Dictionary<string, Dictionary<string, double>>();

            foreach(string fullFileName in fileNames)
            {
                FileInfo fileInfo = new FileInfo(fullFileName);
                string extension = fileInfo.Extension;
                long size = fileInfo.Length;
                double kbSize = Math.Round(size / 1024.0, 3);

                if (!filesDate.ContainsKey(extension))
                {
                    filesDate.Add(extension, new Dictionary<string, double>());
                }

                filesDate[extension].Add(fileInfo.Name, kbSize);
            }

            Dictionary<string, Dictionary<string, double>> sortedDict = filesDate
                .OrderByDescending(kvp => kvp.Value.Count)
                .ThenBy(kvp => kvp.Key)
                .ToDictionary(a => a.Key, b => b.Value);

            List<string> res = new List<string>();

            foreach(var item in sortedDict)
            {
                res.Add(item.Key);

                foreach(var fileData in item.Value.OrderBy(kvp => kvp.Value))
                {
                    res.Add($"--{fileData.Key} - {fileData.Value}kb");
                }

            }

            string filePath = Path.Combine(Environment
                .GetFolderPath(Environment
                .SpecialFolder.Desktop),
                "output.txt");

            File.WriteAllLines(filePath, res);
        }
    }
}
