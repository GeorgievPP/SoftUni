﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace P02.ShootForTheWin
{
    class ShootForTheWin
    { //  07 aPRIL 2020
        static void Main(string[] args)
        {
            int[] targets = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int countTargets = 0;

            int currentTargetValue = 0;

            while(true)
            {
                string command = Console.ReadLine();

                if(command == "End")
                {
                    break;
                }
                else
                {
                    int index = int.Parse(command);

                    if(index >= 0 && index <= targets.Length -1)
                    {
                        if(targets[index] != -1)
                        {
                            currentTargetValue = targets[index];

                            targets[index] = -1;

                            countTargets++;

                            for(int i = 0; i < targets.Length; i++)
                            {
                                if(targets[i] != -1)
                                {
                                    if (targets[i] > currentTargetValue)
                                    {
                                        targets[i] -= currentTargetValue;

                                    }
                                    else if (targets[i] <= currentTargetValue)
                                    {
                                        targets[i] += currentTargetValue;

                                    }
                                }
                            }
                        }
                    }
                }
            }

            Console.Write($"Shot targets: {countTargets} -> ");
            Console.WriteLine(string.Join(" ", targets));
        }
    }
}
