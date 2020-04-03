using System;

namespace CollectionHierarchy.Models
{
    public class AddCollection<T> : AddableCollection<T>
    {
        public override int Add(T item)
        {
            if (item != null)
            {
                this.items.Add(item);
                return this.items.Count - 1; 
            }

            throw new ArgumentNullException();
        }
    }
}
