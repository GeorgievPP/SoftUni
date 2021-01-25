using System.IO;

namespace P04.MergeFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader readerOne = new StreamReader("../../../FileOne.txt"))
            {
                string lineOne = readerOne.ReadLine();

                using (StreamReader readerTwo = new StreamReader("../../../FileTwo.txt"))
                {
                    string lineTwo = readerTwo.ReadLine();

                    using (StreamWriter writer = new StreamWriter("../../../Output"))
                    {
                        while (lineOne != null)
                        {
                            writer.WriteLine(lineOne);
                            writer.WriteLine(lineTwo);

                            lineOne = readerOne.ReadLine();
                            lineTwo = readerTwo.ReadLine();

                        }
                    }
                }
            }
        }
    }
}
