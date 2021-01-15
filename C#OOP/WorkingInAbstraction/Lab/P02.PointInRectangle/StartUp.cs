using System;
using System.Linq;

namespace P02.PointInRectangle
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            int[] size = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var rectangle = new Rectangle(size[3], size[0], size[1], size[2]);

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {

                int[] coordinates = Console.ReadLine().Split().Select(int.Parse).ToArray();

                Console.WriteLine(rectangle.Contains(new Point(coordinates[0], coordinates[1])));

            }

        }
    }
}
