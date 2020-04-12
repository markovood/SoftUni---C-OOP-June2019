using System;
using System.Collections.Generic;

namespace P03.DetailPrinter
{
    public class Manager : IEmployee
    {
        public Manager(string name, ICollection<string> documents)
        {
            this.Name = name;
            this.Documents = new List<string>(documents);
        }

        public IReadOnlyCollection<string> Documents { get; set; }

        public string Name { get; }

        public string Details()
        {
            return this.Name +
                Environment.NewLine + "  " +
                string.Join(Environment.NewLine + "  ", this.Documents);
        }
    }
}
