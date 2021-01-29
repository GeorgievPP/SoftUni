using P08.MilitaryElite.Enumeration;

namespace P08.MilitaryElite.Contracts
{
    public interface IMission
    {
        string CodName { get; }

        State State { get; }

        void CompleteMission();

    }
}
