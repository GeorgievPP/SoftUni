using System;

namespace Problem10.TopNumber
{
    class TopNumber
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            ReturnMasterNumbers(n);
        }

        private static void ReturnMasterNumbers(int n)
        {
            for (int i = 0; i <= n; i++)
            {

                string currNum = i.ToString();

                bool isDigit = false;

                int sumOfDigit = 0;

                foreach (var curr in currNum)
                {
                    int parseNumber = (int)curr;

                    if (parseNumber % 2 == 1)
                    {
                        isDigit = true;

                    }

                    sumOfDigit += parseNumber;


                }

                if (sumOfDigit % 8 == 0 && isDigit)
                {
                    Console.WriteLine(i);
                }

            }
        }
    }
}
