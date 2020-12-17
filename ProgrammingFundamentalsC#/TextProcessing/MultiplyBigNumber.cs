using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05._MultiplyBigNumber
{
    class MultiplyBigNumber
    {
        static void Main(string[] args)
        {
            char[] firstNum = Console.ReadLine().ToCharArray();

            int multiplier = int.Parse(Console.ReadLine());

            if (multiplier == 0)
            {
                Console.WriteLine(0);
                return;

            }

            StringBuilder sb = new StringBuilder();

            int reminder = 0;
            for(int i = firstNum.Length -1; i >= 0; i--)
            {
                char currentCh = firstNum[i];

                int currentNum = int.Parse(currentCh.ToString());

                int sum = (currentNum * multiplier) + reminder;

                sb.Append(sum % 10);

                reminder = sum / 10;

            }

            if(reminder != 0)
            {
                sb.Append(reminder);

            }

            List<char> resultArr = sb.ToString()
                .Reverse()
                .ToList();

            RemoveTrailingZeroes(resultArr);

            Console.WriteLine(string.Join("", resultArr));

        }

        private static void RemoveTrailingZeroes(List<char> resultArr)
        {
            if(resultArr[0] == '0')
            {
                int zeroesCount = 0;

                for(int i = 1; i < resultArr.Count; i++)
                {
                    if(resultArr[i] != '0' )
                    {
                        zeroesCount = i;

                    }

                }
                for(int i = 0; i < zeroesCount; i++)
                {
                    resultArr.RemoveAt(0);

                }
               
            }
        }
    }
}
