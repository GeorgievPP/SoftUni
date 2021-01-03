using System;
using System.Collections.Generic;

namespace ListOfProducts
{
    class ListOfProducts
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<string> productList = new List<string>();


            for(int i = 0; i < n; i++)
            {
                string product = Console.ReadLine();

                productList.Add(product);

            }

            productList.Sort();

            for (int i = 0; i < productList.Count; i ++)
            {
                Console.WriteLine($"{i + 1}.{productList[i]}");
            }
        }
    }
}
