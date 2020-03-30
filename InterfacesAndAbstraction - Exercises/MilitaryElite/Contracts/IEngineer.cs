using System.Collections.Generic;

namespace MilitaryElite.Contracts
{
    public interface IEngineer
    {
        IReadOnlyCollection<IRepairable> Repairs { get; }
    }
}
