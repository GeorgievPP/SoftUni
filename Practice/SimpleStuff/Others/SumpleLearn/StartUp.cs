using LToWEnAndTP.Models.CSharpTeo.OOPFolder;
using System;

namespace LToWEnAndTP
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Inheritance has = new Inheritance();


            Console.WriteLine(has.Info());
            Console.WriteLine(has.ExtendInfo());
        }
    }
}
