using System;
using System.Linq;
using System.Text;

namespace Problem01.ActivationKeys2
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            StringBuilder sb = new StringBuilder(input);

            string command;

            while((command = Console.ReadLine()) != "Generate")
            {
                string[] cmdArgs = command.Split(">>>", StringSplitOptions.RemoveEmptyEntries).ToArray();

                string cmd = cmdArgs[0];

                string arg = cmdArgs[1];

                if(cmd == "Contains")
                {
                    string currentKey = sb.ToString();

                    if (currentKey.Contains(arg))
                    {
                        Console.WriteLine($"{currentKey} contains {arg}");

                        continue;

                    }
                    else
                    {
                        Console.WriteLine("Substring not found!");

                        continue;
                    }
                }

                else if(cmd == "Flip")
                {
                    int startIndex = int.Parse(cmdArgs[2]);

                    int endIndex = int.Parse(cmdArgs[3]);

                    int length = endIndex - startIndex;

                    string key = sb.ToString();


                    string old = key.Substring(startIndex, length);

                    sb.Remove(startIndex, length);


                    if(arg == "Upper")
                    {
                        old = old.ToUpper();

                        
                    }

                    else
                    {
                        old = old.ToLower();
                    }

                    sb.Insert(startIndex, old);

                    Console.WriteLine(sb.ToString());

                    continue;
                }

                else if(cmd == "Slice")
                {
                    int startIndex = int.Parse(arg);

                    int endIndex = int.Parse(cmdArgs[2]);

                    sb.Remove(startIndex, endIndex - startIndex);

                    Console.WriteLine(sb.ToString());

                    continue;
                }

            }

            Console.WriteLine($"Your activation key is: {sb.ToString()}");
        }
    }
}
