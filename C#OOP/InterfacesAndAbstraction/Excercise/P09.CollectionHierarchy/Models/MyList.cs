using P09.CollectionHierarchy.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace P09.CollectionHierarchy.Models
{
    public class MyList : AddRemoveCollection, IUsed
    {
        public MyList() : base()
        {
        }

        public int Used => this.List.Count;

        public override string Remove()
        {
            string element = this.List[0];
            this.List.RemoveAt(0);

            return element;
        }
    }
}
