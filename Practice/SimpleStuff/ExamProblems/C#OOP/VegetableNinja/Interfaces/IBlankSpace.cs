using VegetableNinja.Enumerations;

namespace VegetableNinja.Interfaces
{
    public interface IBlankSpace : IGameObject
    {
        int GrowthTime { get; }

        VegetableType VegetableHolder { get; }

        void Grow();
    }
}
