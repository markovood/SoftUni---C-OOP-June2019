using System;
using System.Collections.Generic;

using CollectionHierarchy.Contracts;

namespace CollectionHierarchy.Models
{
    public abstract class AddableCollection<T> : IAddable<T>
    {
        protected List<T> items;

        protected AddableCollection()
        {
            this.items = new List<T>(); ;
        }

        public virtual int Add(T item)
        {
            const int INITIAL_INDEX = 0;
            if (item != null)
            {
                this.items.Insert(INITIAL_INDEX, item);
                return INITIAL_INDEX;
            }

            throw new ArgumentNullException();
        }
    }
}
