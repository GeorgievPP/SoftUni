using System;
using System.Collections.Generic;
using System.Text;

namespace Problem07.StringExplosion
{
    class StringExplosion
    {
        static void Main(string[] args)
        {
            string feildExplosions = Console.ReadLine();

            int bomb = 0;



            for(int i = 0; i < feildExplosions.Length; i++ )
            {
                var let = feildExplosions[i];

                if(let == '>')
                {
                    bomb += int.Parse(feildExplosions[i + 1].ToString());

                    continue;
                }

                if(bomb > 0)
                {
                    feildExplosions = feildExplosions.Remove(i, 1);

                    i--;

                    bomb--;
                }

            }

            Console.WriteLine(feildExplosions);


        }
    }
}
