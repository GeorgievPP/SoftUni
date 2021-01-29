using System;
using P08.MilitaryElite.Contracts;

namespace P08.MilitaryElite.Models
{
    public class Spy : Soldier, ISpy
    {
        public Spy(int id, string firstName, string lastName, int codeNumber) 
            : base(id, firstName, lastName)
        {
            this.CodeNumber = codeNumber;
        }

        public int CodeNumber { get; private set; }

        public override string ToString()
        {
            return base.ToString() 
                + Environment.NewLine 
                + $"CodeNumber: {this.CodeNumber}";
        }
    }
}
