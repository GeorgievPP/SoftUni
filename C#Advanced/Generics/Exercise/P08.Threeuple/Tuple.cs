using System;
using System.Collections.Generic;
using System.Text;

namespace Tuple
{
    public class Tuple<TFirst, TSecond, TTird>
    {

        public Tuple(TFirst firstItem, TSecond secondItem, TTird tirdItem)
        {

            this.FirstItem = firstItem;
            this.SecondItem = secondItem;
            this.TirdItem = tirdItem;

        }

        public TFirst FirstItem { get; set; }

        public TSecond SecondItem { get; set; }

        public TTird TirdItem { get; set; }

        public override string ToString()
        {
            return $"{this.FirstItem} -> {this.SecondItem} -> {this.TirdItem}";

        }
    }

}