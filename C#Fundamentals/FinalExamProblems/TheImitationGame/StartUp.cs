using System;
using System.Linq;
using System.Text;

namespace Problem01.TheImitationGame2
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            StringBuilder sb = new StringBuilder(input);

            string command;

            while((command = Console.ReadLine()) != "Decode")
            {
                string[] cmdArgs = command.Split('|', StringSplitOptions.RemoveEmptyEntries).ToArray();

                string cmd = cmdArgs[0];

                if(cmd == "Move")
                {
                    int length = int.Parse(cmdArgs[1]);

                    string subs = sb.ToString(0, length);

                    sb.Remove(0, length);

                    sb.Append(subs);

                    continue;
                }

                else if( cmd == "Insert")
                {
                    int index = int.Parse(cmdArgs[1]);

                    string value = cmdArgs[2];

                    sb.Insert(index, value);

                    continue;
                }

                else if( cmd == "ChangeAll")
                {
                    string old = cmdArgs[1];

                    string newSt = cmdArgs[2];

                    sb.Replace(old, newSt);

                    continue;
                }
            }

            Console.WriteLine($"The decrypted message is: {sb.ToString()}");
        }
    }
}
