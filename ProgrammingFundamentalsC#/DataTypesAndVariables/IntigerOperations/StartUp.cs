﻿using System;

namespace DataTypesAndVariables
{
    class IntigerOperations
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());
            int thirdNum = int.Parse(Console.ReadLine());
            int fourthNum = int.Parse(Console.ReadLine());

            int sum = firstNum + secondNum;
            sum /= thirdNum;
            sum *= fourthNum;

            Console.WriteLine(sum);
        }
    }
}