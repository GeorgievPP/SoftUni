using Bakery.Models.Drinks.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bakery.Models.Drinks
{
    public class Drink : IDrink
    {
        public string Name => throw new NotImplementedException();

        public int Portion => throw new NotImplementedException();

        public decimal Price => throw new NotImplementedException();

        public string Brand => throw new NotImplementedException();
    }
}
