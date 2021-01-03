using System;

namespace StrongNumber
{
    class StrongNumber
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int temp = num;
            int totalFactorialSum = 0;
            while(temp >0 )
            {
                int digit = temp % 10;
                temp /= 10;

                int currentFactorielSum = 1;

                for (int i = 1; i <= digit; i++)
                {
                    currentFactorielSum *= i;
                }

                totalFactorialSum += currentFactorielSum;
            }

            if (totalFactorialSum == num)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
        }


    }
}
