using P08.MilitaryElite.Enumeration;

namespace P08.MilitaryElite.Contracts
{
    public interface ISpecialisedSoldier :IPrivate
    {
        Corps Corps { get; }
    }
}
