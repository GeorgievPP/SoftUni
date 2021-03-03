using System;

namespace P03.Generate0._1Vectors
{
    class Program
    {
        // lexicographic order

        static void Main(string[] args)
        {
            int bits = int.Parse(Console.ReadLine());
            int[] vector = new int[bits];
            Gen01(vector, 0);
        }

        private static void Gen01(int[] vector, int index)
        {
            if(index == vector.Length)
            {
                Console.WriteLine(String.Join("", vector));
                return;
            }

            for (int i = 0; i <= 1 ; i++)
            {
                vector[index] = i;
                Gen01(vector, index + 1);
            }
        }
    }
}
