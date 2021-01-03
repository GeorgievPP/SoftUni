using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonDontGo
{
    class PokemonDontGo
    {
        static void Main(string[] args)
        {
            List<int> sequence = Console.ReadLine().Split().Select(int.Parse).ToList();

            int sumOfAllRemovedEl = 0;

            while(sequence.Count != 0)
            {
                int index = int.Parse(Console.ReadLine());
                if (index < 0 )
                {
                    int element = sequence[0];

                    sequence.RemoveAt(0);
                    sumOfAllRemovedEl += element;

                    sequence.Insert(0, sequence[sequence.Count - 1]);

                    for(int i = 0; i < sequence.Count; i++)
                    {
                        if (sequence[i] > element)
                        {
                            sequence[i] -= element;
                        }
                        else if(sequence[i] <= element)
                        {
                            sequence[i] += element;
                        }

                    }

                }
                else if (index >= sequence.Count)
                {
                    int element = sequence[sequence.Count - 1];

                    index = sequence.Count - 1;
                    sequence.RemoveAt(index);
                    sumOfAllRemovedEl += element; 

                    sequence.Add(sequence[0]);

                    for(int i = 0; i < sequence.Count; i++)
                    {
                        if(sequence[i] > element)
                        {
                            sequence[i] -= element;

                        }
                        else if(sequence[i] <= element)
                        {
                            sequence[i] += element;
                        }
                    }

                }
                else
                {
                    int element = sequence[index];

                    sequence.RemoveAt(index);
                    sumOfAllRemovedEl += element;

                    for(int i = 0; i < sequence.Count; i++)
                    {
                        if(sequence[i] > element )
                        {
                            sequence[i] -= element;

                        }
                        else if (sequence[i] <= element)
                        {
                            sequence[i] += element;
                        }
                    }
                }
            }

            Console.WriteLine(sumOfAllRemovedEl);
        }
    }
}
