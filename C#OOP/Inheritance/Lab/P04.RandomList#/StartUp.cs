using System;

namespace CustomRandomList
{
    public class StartUp
    {
        static void Main(string[] args)
        {  /// 50/100

            var random = new RandomList();

            Console.WriteLine(random.RandomInt());

            random.Add("Pesho");
            random.Add(5);
            random.Add("Gosho");

            var test = random[0];
            var test1 = random[1];
        }
    }
}
