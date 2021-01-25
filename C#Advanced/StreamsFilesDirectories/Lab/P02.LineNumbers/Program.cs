using System;
using System.IO;

namespace P02.LineNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            using(StreamReader reader = new StreamReader("../../../Input.txt"))
            {
                string line = reader.ReadLine();
                int counter = 1;

                using(StreamWriter writer = new StreamWriter("../../../Output.txt"))
                {
                    while (line != null)
                    {
                        writer.WriteLine($"{counter}. {line}");
                        line = reader.ReadLine();
                        counter++;
                    }
                }
            }
        }
    }
}
