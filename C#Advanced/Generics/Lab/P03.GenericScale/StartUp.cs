﻿using System;

namespace GenericScale
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            var scale = new EqualityScale<int>(5, 5);

            scale.AreEqual();

        }
    }
}
