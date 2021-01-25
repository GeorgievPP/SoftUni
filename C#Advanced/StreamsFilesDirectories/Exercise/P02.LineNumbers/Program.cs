using System;
using System.IO;

namespace P02.LineNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader reader = new StreamReader("../../../text.txt"))
            {
                string line = reader.ReadLine();
                int counter = 1;
                

                using (StreamWriter writer = new StreamWriter("../../../output.txt"))
                {
                    while (line != null)
                    {
                        int numberOfDigits = 0;
                        int numbersOfLetters = 0;

                        for (int i = 0; i < line.Length; i++)
                        {
                            if (!Char.IsLetterOrDigit(line[i]) && !Char.IsWhiteSpace(line[i]))
                            {
                                numberOfDigits++;
                            }
                            if (Char.IsLetter(line[i]))
                            {
                                numbersOfLetters++;
                            }
                        }
                        
                        writer.WriteLine($"Line {counter}: {line} ({numbersOfLetters})({numberOfDigits})");
                        line = reader.ReadLine();
                        counter++;
                    }
                }
            }
        }
    }
}
