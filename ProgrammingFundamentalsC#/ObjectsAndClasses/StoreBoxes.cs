using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem07.StoreBoxes
{

    public class Item
    {
        public string Name
        {
            get;
            set;

        }

        public decimal Price
        {
            get;
            set;

        }
    }

    public class Box
    {
        public string SerialNumber
        {
            get;
            set;

        }
        public Item Item
        {
            get;
            set;

        }
        public int ItemQuantity
        {
            get;
            set;
        }
        public decimal PriceForBox
            => Item.Price * ItemQuantity; 
    }
    class StoreBoxes
    {
        static void Main(string[] args)
        {
            List<Box> boxes = new List<Box>();

            string input;

            while((input = Console.ReadLine()) != "end")
            {

                string[] inputInfo = input.Split(" ");



                string serialNumber = inputInfo[0];

                string itemName = inputInfo[1];

                int itemQuantity = int.Parse(inputInfo[2]);

                decimal itemPrice = decimal.Parse(inputInfo[3]);




                Item item = new Item();


                item.Name = itemName;

                item.Price = itemPrice;



                Box box = new Box();


                box.SerialNumber = serialNumber;

                box.ItemQuantity = itemQuantity;

                box.Item = item;


                boxes.Add(box);

            }

            foreach(var currentBox in boxes.OrderByDescending(x => x.PriceForBox))
            {

                Console.WriteLine(currentBox.SerialNumber);

                Console.WriteLine($"-- {currentBox.Item.Name} - ${currentBox.Item.Price:f2}: {currentBox.ItemQuantity}");

                Console.WriteLine($"-- ${currentBox.PriceForBox:f2}");

            }
        }
    }
}
