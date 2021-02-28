using P09.CollectionHierarchy.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace P09.CollectionHierarchy.Models
{
    public abstract class Collection : IAdd
    {
        private List<string> list;

        public Collection()
        {
            this.list = new List<string>();
        }

        protected IList<string> List
        {
            get
            {
                return this.list;
            }
        }

        public abstract int Add(string element);
       
    }
}
