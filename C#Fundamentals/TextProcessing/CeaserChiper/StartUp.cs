using System;
using System.Text;

namespace Problem04.CeaserChiper
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();

            StringBuilder sb = new StringBuilder();

            int length = word.Length;

            ReturnCryptedMessage(word, sb, length);

            Console.WriteLine(sb.ToString());
        }

        private static void ReturnCryptedMessage(string word, StringBuilder sb, int length)
        {
            for (int i = 0; i < length; i++)
            {
                int num = (char)(word[i]) + 3;

                char c = Convert.ToChar(num);

                sb.Append(c);

            }
        }
    }
}
