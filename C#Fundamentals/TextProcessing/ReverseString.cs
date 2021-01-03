using System;

namespace P01.ReverseString
{
    class ReverseString
    {
        static void Main(string[] args)
        {
            string word;

            while((word = Console.ReadLine()) != "end")
            {
                string reverse = "";

                for(int i = word.Length-1; i>= 0; i--)
                {
                    reverse += word[i];
                }

                Console.WriteLine($"{word} = {reverse}");
            }

           
        }
    }
}
