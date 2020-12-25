using System;

namespace Login
{
    class Login
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();

            string correctPass = "";

            for (int i = username.Length - 1; i >=0; i--)
            {
                correctPass += username[i];
            }
            
            for (int i = 1; i <= 4; i++)
            {
                string password = Console.ReadLine();
                if (password == correctPass)
                {
                    Console.WriteLine($"User {username} logged in.");
                    break;
                }
                if (i <= 3)
                {
                    Console.WriteLine("Incorrect password. Try again.");
                }
                else
                {
                    Console.WriteLine($"User {username} blocked!");
                }
            }
        }
    }
}
