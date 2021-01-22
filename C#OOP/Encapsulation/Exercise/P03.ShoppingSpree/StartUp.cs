using System;

namespace P03.ShoppingSpree
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            try
            {
                Core.Engine engine = new Core.Engine();

                engine.Run();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
