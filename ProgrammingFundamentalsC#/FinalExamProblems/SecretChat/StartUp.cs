using System;
using System.Collections.Generic;
using System.Text;

namespace Problem01.SecretChat
{
    class StartUp
    {  //100/100
        static void Main(string[] args)
        {
            string message = Console.ReadLine();

            StringBuilder sb = new StringBuilder(message);

            string command;

            while((command = Console.ReadLine()) != "Reveal")
            {
                string[] input = command.Split(":|:");

                string cmd = input[0];

                if(cmd == "InsertSpace")
                {
                    int index = int.Parse(input[1]);

                    string space = " ";

                    sb.Insert(index, space);

                    Console.WriteLine(sb.ToString());
                    continue;

                }
                else if(cmd == "Reverse")
                {
                    string sub = input[1];

                    message = sb.ToString();


                    if(message.Contains(sub))
                    {
                        int startIndex = message.IndexOf(sub);

                        int length = sub.Length;

                        string help = "";

                        sb.Remove(startIndex, length);

                        for(int i = sub.Length - 1; i >= 0; i--)
                        {
                            help += sub[i];

                        }

                        sb.Append(help);

                        Console.WriteLine(sb.ToString());
                        continue;

                    }
                    else
                    {
                        Console.WriteLine("error");
                        continue;

                    }
                
                }

                else if (cmd == "ChangeAll")
                {
                    string oldString = input[1];

                    string newString = input[2];


                    string help = sb.ToString();

                    if(help.Contains(oldString))
                    {
                        sb.Replace(oldString, newString);

                        Console.WriteLine(sb.ToString());
                        continue;

                    }
                }
            }

            Console.WriteLine($"You have a new text message: {sb.ToString()}");

        }
    }
}
