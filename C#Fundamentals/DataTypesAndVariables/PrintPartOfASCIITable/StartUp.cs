﻿using System;

namespace PrintPartOfASCIITable
{
    class PrintPartOfASCIITable
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());



            for ( int i = start; i <= end; i++)
            {
                char help = (char)i;
                Console.Write(help + " ");
            }
        }
    }
}
