using System;
using System.Collections.Generic;
using System.Text;

namespace Minedraft.Models
{
    public abstract class Item
    {
        protected Item(string id)
        {
            this.Id = id;
        }

        public string Id { get; set; }
    }
}
