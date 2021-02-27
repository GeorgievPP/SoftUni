using System;
using System.Collections.Generic;
using System.Text;

namespace P07.FoodShortage.Contracts
{
    public interface IBuyer
    {
        string Name { get; }
        int Food { get; }

        void BuyFood();

    }
}
