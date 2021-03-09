using Bakery.Core.Contracts;
using Bakery.Models.BakedFoods;
using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables;
using Bakery.Models.Tables.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bakery.Core
{
    public class Controller : IController
    {

        private List<IBakedFood> bakedFoods;
        private List<IDrink> drinks;
        private List<ITable> tables;
        private decimal totalIncome = 0m;

        public Controller()
        {
            this.bakedFoods = new List<IBakedFood>();
            this.drinks = new List<IDrink>();
            this.tables = new List<ITable>();
        }

        public string AddDrink(string type, string name, int portion, string brand)
        {
            IDrink drink = null;
            switch (type)
            {
                case nameof(Tea):
                    drink = new Tea(name, portion, brand);
                    break;
                case nameof(Water):
                    drink = new Water(name, portion, brand);
                    break;
            }
            if (drink == null)
            {
                return "NotGooooodDrink";
            }

            this.drinks.Add(drink);

            return $"Added {name} ({brand}) to the drink menu";
        }

        public string AddFood(string type, string name, decimal price)
        {
            IBakedFood food = null;
            switch (type)
            {
                case nameof(Bread):
                    food = new Bread(name, price);
                    break;
                case nameof(Cake):
                    food = new Cake(name, price);
                    break;
            }
            if(food == null)
            {
                return "NotGooooodFoood";
            }

            this.bakedFoods.Add(food);

            return $"Added {name} ({type}) to the menu";
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            ITable table = null;
            switch (type)
            {
                case nameof(InsideTable):
                    table = new InsideTable(tableNumber, capacity);
                    break;
                case nameof(OutsideTable):
                    table = new OutsideTable(tableNumber, capacity);
                    break;
            }
            if (table == null)
            {
                return "NotGooooodTableee";
            }

            this.tables.Add(table);

            return $"Added table number {tableNumber} in the bakery";
        }

        public string GetFreeTablesInfo()
        {
            var notReservedTables = this.tables.Where(x => x.IsReserved == false);

            StringBuilder sb = new StringBuilder();

            foreach(var table in notReservedTables)
            {
                sb.AppendLine(table.GetFreeTableInfo());
            }

            return sb.ToString().TrimEnd();
        }

        public string GetTotalIncome()
        {
            return $"Total income: {totalIncome:f2}lv";
        }

        public string LeaveTable(int tableNumber)
        {
            var table = this.tables.FirstOrDefault(x => x.TableNumber == tableNumber);
            if(table == null)
            {
                return "LeaveTableError";
            }

            StringBuilder sb = new StringBuilder();


            decimal bill = table.GetBill() + table.NumberOfPeople * table.PricePerPerson;
            totalIncome += bill;

            sb.AppendLine($"Table: {table.TableNumber}");
            sb.AppendLine($"Bill: {bill:f2}");

            table.Clear();

            return sb.ToString().TrimEnd();
        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            var table = this.tables.FirstOrDefault(x => x.TableNumber == tableNumber);
            if (table == null)
            {
                return $"Could not find table {tableNumber}";
            }

            var drink = this.drinks.FirstOrDefault(x => x.Name == drinkName);
            if (drink == null)
            {
                return $"There is no {drinkName} {drinkBrand} available";
            }

            table.OrderDrink(drink);

            return $"Table {tableNumber} ordered {drinkName} {drinkBrand}";

        }

        public string OrderFood(int tableNumber, string foodName)
        {
            var table = this.tables.FirstOrDefault(x => x.TableNumber == tableNumber);
            if(table == null)
            {
                return $"Could not find table {tableNumber}";
            }

            var food = this.bakedFoods.FirstOrDefault(x => x.Name == foodName);
            if(food == null)
            {
                return $"No {foodName} in the menu";
            }

            table.OrderFood(food);

            return $"Table {tableNumber} ordered {foodName}";
        }

        public string ReserveTable(int numberOfPeople)
        {
            var table = this.tables.FirstOrDefault(x => x.IsReserved == false && x.Capacity >= numberOfPeople);
            if(table == null)
            {
                return $"No available table for {numberOfPeople} people";
            }

            table.Reserve(numberOfPeople);

            return $"Table {table.TableNumber} has been reserved for {numberOfPeople} people";
        }
    }
}
