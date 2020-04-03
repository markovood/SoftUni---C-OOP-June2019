using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy.Contracts
{
    public interface IAddable<T>
    {
        int Add(T item);
    }
}
