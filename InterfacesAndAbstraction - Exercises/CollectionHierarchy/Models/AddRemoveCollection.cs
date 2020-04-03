using System;

using CollectionHierarchy.Contracts;

namespace CollectionHierarchy.Models
{
    public class AddRemoveCollection<T> : AddableCollection<T>, IRemovable<T>
    {
        public virtual T Remove()
        {
            if (this.items.Count > 0)
            {
                T item = this.items[this.items.Count - 1];
                this.items.RemoveAt(this.items.Count - 1);
                return item;
            }

            throw new ArgumentOutOfRangeException();
        }
    }
}
