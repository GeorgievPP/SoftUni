using System;
using System.Linq;

namespace Tuple
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            var personInfo = Console.ReadLine().Split(" ", 4).ToArray();

            string fullName = $"{personInfo[0]} {personInfo[1]}";

            string address = $"{personInfo[2]}";

            string town = $"{personInfo[3]}";

            var nameAndBeer = Console.ReadLine().Split();

            string name = nameAndBeer[0];

            int beerAmount = int.Parse(nameAndBeer[1]);

            bool drunk = nameAndBeer[2] == "drunk";

            var thirdInput = Console.ReadLine().Split();

            var firstArgument = thirdInput[0];

            var secondArgument = double.Parse(thirdInput[1]);

            var tirdArgument = thirdInput[2];

            Tuple<string, string, string> firstTuple = new Tuple<string, string, string>(fullName, address, town);

            Tuple<string, int, bool> secondTuple = new Tuple<string, int, bool>(name, beerAmount, drunk);

            Tuple<string, double, string> thirdTuple = new Tuple<string, double, string>(firstArgument, secondArgument, tirdArgument);

            Console.WriteLine(firstTuple);

            Console.WriteLine(secondTuple);

            Console.WriteLine(thirdTuple);
        }
    }
}
