﻿using System;
using System.Collections.Generic;
using System.Text;

namespace P10.ExplicitInterfaces.Contracts
{
    public interface IPerson
    {
        string Name { get; }
        int Age { get; }

        string GetName();
    }
}
