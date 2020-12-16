using System;
using System.Linq;

namespace EqualSum
{
    class EqualSum
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int bestIndex = 0;

            bool sumIsEqual = false;

            for(int i = 0; i < arr.Length; i++)
            {
                int n = arr[i];

                int rightSum = 0;

                for(int j = i + 1; j < arr.Length; j++)
                {
                    rightSum += arr[j];
                }

                int leftSum = 0;

                for (int j = i - 1; j >= 0; j--)
                {
                    leftSum += arr[j];
                }

                if (rightSum == leftSum)
                {
                    bestIndex = i;
                    sumIsEqual = true;
                    break;
                }
            }
            if (sumIsEqual)
            {
                Console.WriteLine(bestIndex);
            }
            else
            {
                Console.WriteLine("no");
            }



        }
    }
}
