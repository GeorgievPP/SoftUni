using System;

namespace Problem4
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int adresEnd = int.Parse(Console.ReadLine());
            int adresStart = int.Parse(Console.ReadLine());
            int adresPower = int.Parse(Console.ReadLine());

            for (int i = adresStart; i >= adresEnd; i--)
            {
                if (i % 2 == 0 && i % 3 == 0)
                {
                    if (i == adresPower)
                    {
                        break;
                    }
                    else
                    {
                        Console.Write($"{i} ");
                    }
                }
            

            }
        }
    }
}
