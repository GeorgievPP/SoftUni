using System;
using System.Collections.Generic;
using System.Text;

namespace P04.BorderControl.Contracts
{
    public interface IRobot : IIdentifable
    {
        string Model { get; }

    }
}
