using System;
using System.Linq;
using System.Text;

namespace Strings
{
    class StartUp
    {
        static void Main(string[] args)
        {

            Console.Write("Write a string to see some methods: ");
            string word = Console.ReadLine();

            Console.WriteLine("-----------------------");

            Console.WriteLine("Remove Duplicate characters from string:");


            Console.WriteLine($"1.{RemoveDuplicateChars(word)}");
            Console.WriteLine($"2.{RemoveDuplicateChars2(word)}");
            Console.WriteLine("--------------------------------");

            Console.WriteLine("How to reverse string:");

            Console.WriteLine($"1.{ReverseStr(word)}");
            Console.WriteLine($"2.{ReverseStrRecursion(word)}");
            Console.WriteLine("-------------------------------");

            Console.WriteLine("How to count number of words in a string:");

            Console.WriteLine($"1.{GetCountOfWords(word)}");
            Console.WriteLine($"2.{GetCountOfWords2(word)}");
            Console.WriteLine("-------------------------------");

            Console.WriteLine("Palindrome word:");

            IsWordPalindrome(word);
            Console.WriteLine("--------------------------");

            Console.WriteLine("All substrings in a string:");

            AllSubstringsInString(word);
            


        }

        public static string RemoveDuplicateChars(string word)
        {

            string result = new string(word
                .Distinct()
                .ToArray());

            return result;
        }


        public static string RemoveDuplicateChars2(string word)
        {

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < word.Length; i++)
            {

                if(!sb.ToString().Contains(word[i]))
                {

                    sb.Append(word[i]);

                } 

            }

            return sb.ToString();
        }


        public static string ReverseStr(string word)
        {

            char[] result = new char[word.Length];

            int lenght = word.Length - 1;

            foreach(char ch in word)
            {

                result[lenght--] = ch;

            }

            return new string(result);

        }

        public static string ReverseStrRecursion(string word)
        {

            if(word.Length == 1)
            {

                return word;

            }

            return word.Last() + ReverseStrRecursion(word.Substring(0, word.Length - 1));

        }

        public static int GetCountOfWords(string str)
        {

            int count = 0;

            if(!string.IsNullOrWhiteSpace(str))
            {
                foreach(string word in str.Split(' '))
                {

                    count++;

                }

            }

            return count;

        }

        public static int GetCountOfWords2(string str)
        {

            string[] words = str.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            return words.Length;

        }

        public static void IsWordPalindrome(string word)
        {

            char[] array = word.ToCharArray();

            Array.Reverse(array);

            if(word.Equals(new string(array)))
            {

                Console.WriteLine($"{word} is palindrome");

            }
            else
            {

                Console.WriteLine($"{word} is not palindrome");

            }
        }

        public static void AllSubstringsInString( string word)
        {


            for (int length = 1; length < word.Length; length++)
            {


                for (int start = 0; start <= word.Length - length; start++)
                {

                    string substring = word.Substring(start, length);

                    Console.WriteLine(substring);

                }
            }
        }


    }
}
