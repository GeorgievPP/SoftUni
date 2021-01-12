using System;

namespace BoxOfT
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            var box = new Box<int>();

            box.Add(10);
            box.Add(20);
            box.Add(40);

            Console.WriteLine(box.Remove());

            box.Add(4);
            box.Add(6);

            Console.WriteLine(box.Remove());
        }
    }
}
