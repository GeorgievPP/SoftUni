using System;

namespace VendingMachine
{
    class VendingMachine
    {
        static void Main(string[] args)
        {
            double sum = 0;
            while (true)
            {
                string commands = Console.ReadLine();
                if (commands == "Start")
                {
                    
                    string products = Console.ReadLine();
                    while (products != "End")
                    {
                       

                        if (products == "Nuts")
                        {
                            sum -= 2.0;
                            if (sum < 0)
                            {
                                Console.WriteLine("Sorry, not enough money");
                                sum += 2.0;
                            }
                            else
                            {
                                Console.WriteLine("Purchased nuts");
                            }
                        }
                        else if (products == "Water")
                        {
                            sum -= 0.70;
                            if (sum < 0)
                            {
                                Console.WriteLine("Sorry, not enough money");
                                sum += 0.70;
                            }
                            else
                            {
                                Console.WriteLine("Purchased water");
                            }
                        }
                        else if (products == "Crisps")
                        {
                            sum -= 1.50;
                            if (sum < 0)
                            {
                                Console.WriteLine("Sorry, not enough money");
                                sum += 1.50;
                            }
                            else
                            {
                                Console.WriteLine("Purchased crisps");
                            }
                        }
                        else if (products == "Soda")
                        {
                            sum -= 0.8;
                            if (sum < 0)
                            {
                                Console.WriteLine("Sorry, not enough money");
                                sum += 0.80;
                            }
                            else
                            {
                                Console.WriteLine("Purchased soda");
                            }
                        }
                        else if (products == "Coke")
                        {
                            sum -= 1.0;
                            if (sum < 0)
                            {
                                Console.WriteLine("Sorry, not enough money");
                                sum += 1.0;
                            }
                            else
                            {
                                Console.WriteLine("Purchased coke");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid product");
                        }

                        products = Console.ReadLine();
                    }
                    if (products == "End")
                    {
                        Console.WriteLine($"Change: {sum:f2}");
                        break;
                    }


                }

                double inserrtCoin = double.Parse(commands);
                if (inserrtCoin == 0.1 || inserrtCoin == 0.2 || inserrtCoin == 0.5 || inserrtCoin == 1 || inserrtCoin == 2)
                {
                    sum += inserrtCoin;
                }
                else
                {
                    Console.WriteLine($"Cannot accept {inserrtCoin}");
                }
            }
        }
    }
}
