﻿using System;

namespace P02.RecursiveDrawing
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            Draw(count);
        }

        private static void Draw(int count)
        {
            if(count == 0)
            {
                return;
            }
            Console.WriteLine(new string ('*', count));
            Draw(count - 1);
            Console.WriteLine(new string('#', count));
        }
    }
}
