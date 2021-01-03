using System;
using System.Linq;
using System.Text;

namespace Problem01
{
    class StartUp
    { //100/100
        static void Main(string[] args)
        {
            string key = Console.ReadLine();

            StringBuilder sb = new StringBuilder(key);

            string command;

            while((command = Console.ReadLine()) != "Finish")
            {
                string[] input = command.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                string cmd = input[0];

                if(cmd == "Replace")
                {
                    string currentCh = input[1];

                    string newCh = input[2];

                    sb.Replace(currentCh, newCh);

                    Console.WriteLine(sb.ToString());

                    continue;

                }

                else if(cmd == "Cut")
                {
                    int startIndex = int.Parse(input[1]);

                    int endIndex = int.Parse(input[2]);

                    if((startIndex >= 0 && startIndex < sb.Length) && (endIndex >= 0 && endIndex < sb.Length))
                    {
                        sb.Remove(startIndex, (endIndex - startIndex) + 1);

                        Console.WriteLine(sb.ToString());

                        continue;

                    }

                    else
                    {
                        Console.WriteLine("Invalid indices!");

                        continue;

                    }
                }

                else if(cmd == "Make")
                {
                    string cmdArgs = input[1];

                    string newStBil = "";

                    if(cmdArgs == "Upper")
                    {
                        newStBil = sb.ToString().ToUpper();

                        sb.Clear();

                        sb.Append(newStBil);

                    }
                    else if(cmdArgs == "Lower")
                    {
                        newStBil = sb.ToString().ToLower();

                        sb.Clear();

                        sb.Append(newStBil);

                    }

                    Console.WriteLine(sb.ToString());


                }

                else if(cmd == "Check")
                {
                    string checkStr = input[1];

                    string stBil = sb.ToString();

                    if(stBil.Contains(checkStr))
                    {
                        Console.WriteLine($"Message contains {checkStr}");

                        continue;
                    }

                    else
                    {
                        Console.WriteLine($"Message doesn't contain {checkStr}");

                        continue;
                    }

                }

                else if( cmd == "Sum")
                {
                    int startIndex = int.Parse(input[1]);

                    int endIndex = int.Parse(input[2]);

                    int sum = 0;

                    if ((startIndex >= 0 && startIndex < sb.Length) && (endIndex >= 0 && endIndex < sb.Length))
                    {
                        string subsStr = sb.ToString(startIndex, (endIndex - startIndex) + 1);

                        foreach(char ch in subsStr)
                        {
                            sum += ch;

                        }

                        Console.WriteLine(sum);

                        continue;

                    }

                    else
                    {
                        Console.WriteLine("Invalid indices!");

                    }


                }


            }


        }
    }
}
