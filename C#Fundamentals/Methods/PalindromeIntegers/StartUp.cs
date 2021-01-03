using System;
using System.Collections.Generic;
using System.Text;

namespace Problem09.PalindromeIntegers
{
    class PalindromeIntegers
    {
        static void Main(string[] args)
        {
            string input;
            while((input = Console.ReadLine()) != "END")
            {
                StringBuilder sb = new StringBuilder();

                for (int i = input.Length - 1; i >= 0; i--)
                {

                    sb.Append(input[i]);

                }

                string newSt = sb.ToString();

                if (input == newSt)
                {
                    Console.WriteLine("true");
                    continue;
                }
                else
                {
                    Console.WriteLine("false");
                    continue;
                }

            }
        }
    }
}
