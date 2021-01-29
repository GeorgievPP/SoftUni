using System;
using System.IO;
using System.Text;

namespace P01.EvenLines
{
    class Program
    {
        static void Main(string[] args)
        {
            using(StreamReader reader = new StreamReader("../../../text.txt"))
            {
                string line = reader.ReadLine();

                 int counter = 0;

                using(StreamWriter writer = new StreamWriter("../../../output.txt"))
                {
                    while(line != null)
                    {
                        string[] lineArr = line.Split();
                      
                        if (counter % 2 == 0)
                        {
                            StringBuilder sb = new StringBuilder();

                            for (int i = lineArr.Length - 1; i >= 0; i--)
                            {
                                sb.Append(lineArr[i] + " ");
                            }

                            ReplaceSymbols(sb);

                            writer.WriteLine(sb.ToString());

                        }

                        counter++;
                        line = reader.ReadLine();

                    }
                }
            }
        }

        private static void ReplaceSymbols(StringBuilder sb)
        {
            sb.Replace("-", "@");
            sb.Replace(",", "@");
            sb.Replace(".", "@");
            sb.Replace("!", "@");
            sb.Replace("?", "@");
        }
    }
}
