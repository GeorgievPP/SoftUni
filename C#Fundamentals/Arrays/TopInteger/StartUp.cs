using System;
using System.Linq;

namespace TopInteger
{
    class TopInteger
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            string result = "";

            for(int i = 0; i < numbers.Length; i++)
            {
                int num = numbers[i];
                bool topInt = true;

                for (int j = i + 1; j < numbers.Length; j++)
                {
                    if(num <= numbers[j])
                    {
                        topInt = false;
                        break;
                    }
                   
                }

                if(topInt)
                {
                    result += num + " ";
                }
            }

            Console.WriteLine(result);
        }
    }
}
