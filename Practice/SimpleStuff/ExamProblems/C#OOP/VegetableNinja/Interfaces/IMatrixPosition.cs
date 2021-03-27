using System;

namespace VegetableNinja.Interfaces
{
    public interface IMatrixPosition : IEquatable<IMatrixPosition>
    {
        int PositionX { get; }

        int PositionY { get; }
    }
}
