using System.Collections.Generic;

namespace MilitaryElite.Contracts
{
    public interface ILieutenantGeneral
    {
        IReadOnlyCollection<IPrivate> Privates { get; }
    }
}
