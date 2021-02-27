using System;
using System.Collections.Generic;
using System.Text;

namespace P04.BorderControl.Contracts
{
    public interface ICitizen : IIdentifable
    {
        string Name { get; }

        int Age { get; }
    }
}
