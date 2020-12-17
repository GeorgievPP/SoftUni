using System;
using System.Linq;

namespace MultiplyEvanByOdds
{
    class MultiplyEvanByOdds
    {
        static void Main(string[] args)
        {
            int number = Math.Abs(int.Parse(Console.ReadLine()));

            int totalResult = GetResult(number);

            Console.WriteLine(totalResult);
           

        }
        static int GetResult(int num)
        {

            int result = 0;
            int evanSum = 0;
            int oddSum = 0;

            while (num > 0)
            {
                int temp = num % 10;

                if (GetEvanSum(temp))
                {
                     evanSum += temp;
                }
                else if (GetOddSum(temp))
                {
                    oddSum += temp;
                }

                num /= 10;
            }

            result = evanSum * oddSum; 
            return result;
        }

        static bool GetEvanSum(int temp)
        {

            return temp % 2 == 0;
        }
        static bool GetOddSum(int temp)
        {
            return temp % 2 == 1;
        }
    }
}
