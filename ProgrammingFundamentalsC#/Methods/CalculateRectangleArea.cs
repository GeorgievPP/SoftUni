using System;

namespace CalculateRectangleArea
{
    class CalculateRectangleArea
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());

            int areaRectangle = GetRectangleArea(a, b);

            Console.WriteLine(areaRectangle);

        }
        static int GetRectangleArea(int x1, int x2)
        {
            int area = x1 * x2;
            return area;
        }
    }
}
