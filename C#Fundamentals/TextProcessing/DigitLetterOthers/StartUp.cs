using System;

namespace P05.DigitsLettersOthers
{
    class DigitLetterOthers
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            string allDigits = "";

            string allLetters = "";

            string everythingElse = "";

            foreach(char symbol in text)
            {
                if(char.IsDigit(symbol))
                {
                    allDigits += symbol;

                }
                else if(char.IsLetter(symbol))
                {
                    allLetters += symbol;

                }
                else
                {
                    everythingElse += symbol;
                }
            }

            Console.WriteLine(allDigits);

            Console.WriteLine(allLetters);

            Console.WriteLine(everythingElse);
        }
    }
}
