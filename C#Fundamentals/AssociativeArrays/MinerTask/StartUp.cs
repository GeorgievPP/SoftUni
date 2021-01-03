using System;
using System.Collections.Generic;

namespace P02.MinerTask
{
    class MinerTask
    {
        static void Main(string[] args)
        {
            Dictionary<string, long> dictOfResource = new Dictionary<string, long>();

            string resource;

            while ((resource = Console.ReadLine()) != "stop")
            {
                int quantity = int.Parse(Console.ReadLine());

                if (!dictOfResource.ContainsKey(resource))
                {
                    dictOfResource[resource] = 0;
                }

                dictOfResource[resource] += quantity;


            }

            foreach (KeyValuePair<string, long> item in dictOfResource)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
