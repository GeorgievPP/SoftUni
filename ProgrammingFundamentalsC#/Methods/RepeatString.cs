using System;

namespace RepeatString
{
    class RepeatString
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string newText = GetNewString(text);

            Console.WriteLine(newText);
        }
        static string GetNewString(string word)
        {
            int n = int.Parse(Console.ReadLine());
            string temp = "";
            for(int i = 0; i < n; i++)
            {
                temp += word;
            }
            return temp;
        }
    }
}
