using P01.Logger.Core.Models;
using System;

namespace P01.Logger
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int countOfAppenders = int.Parse(Console.ReadLine());
            var controller = new Controller();
            controller.Act(countOfAppenders);
        }
    }
}
