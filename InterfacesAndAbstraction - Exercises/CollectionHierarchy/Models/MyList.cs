using System;

namespace CollectionHierarchy.Models
{
    public class MyList<T> : AddRemoveCollection<T>
    {
        public int Used => this.items.Count;

        public override T Remove()
        {
            const int INITIAL_INDEX = 0;
            if (this.items.Count > 0)
            {
                T item = this.items[INITIAL_INDEX];
                this.items.RemoveAt(INITIAL_INDEX);
                return item;
            }

            throw new ArgumentOutOfRangeException();
        }
    }
}
