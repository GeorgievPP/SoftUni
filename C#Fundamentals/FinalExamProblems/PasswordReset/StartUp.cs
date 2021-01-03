using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem01.PasswordReset
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            StringBuilder sb = new StringBuilder(input);


            string command;

            while((command = Console.ReadLine()) != "Done")
            {
                if(command == "TakeOdd")
                {
                    string str = sb.ToString();

                    sb.Clear();

                    for(int i = 1; i < str.Length; i+=2)
                    {
                        sb.Append(str[i]);
                    }

                    Console.WriteLine(sb.ToString());

                    continue;
                }

                else
                {
                    string[] cmdArgs = command.Split().ToArray();

                    string cmd = cmdArgs[0];

                    if (cmd == "Cut")
                    {
                        int index = int.Parse(cmdArgs[1]);

                        int length = int.Parse(cmdArgs[2]);

                        sb.Remove(index, length);

                        Console.WriteLine(sb.ToString());

                        continue;
                    }

                    else if( cmd == "Substitute")
                    {
                        string str = cmdArgs[1];

                        input = sb.ToString();

                        if(input.Contains(str))
                        {
                            string newStr = cmdArgs[2];

                            sb.Replace(str, newStr);

                            Console.WriteLine(sb.ToString());

                            continue;
                        }
                        else
                        {
                            Console.WriteLine("Nothing to replace!");

                            continue;
                        }
                    }

                }

            }

            Console.WriteLine($"Your password is: {sb.ToString()}");

        }
        
    }
}
