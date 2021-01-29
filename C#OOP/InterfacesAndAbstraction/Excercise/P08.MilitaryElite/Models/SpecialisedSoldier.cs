using System;

using P08.MilitaryElite.Contracts;
using P08.MilitaryElite.Enumeration;
using P08.MilitaryElite.Exceptions;

namespace P08.MilitaryElite.Models
{
    public class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        public SpecialisedSoldier(int id, string firstName, string lastName, decimal salary, string corps) 
            : base(id, firstName, lastName, salary)
        {
            this.Corps = this.TryParseCorps(corps);
        }

        public Corps Corps { get; private set; }

        private Corps TryParseCorps(string corpsStr)
        {
            Corps corps;
            bool parsed = Enum.TryParse<Corps>(corpsStr, out corps);

            if (!parsed)
            {
                throw new InvalidCorpsException();
            }

            return corps;
        }

        public override string ToString()
        {
            return base.ToString()
                + Environment.NewLine
                + $"Corps: {this.Corps.ToString()}";
        }
    }
}
