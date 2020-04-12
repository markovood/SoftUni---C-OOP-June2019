using System;
using System.Collections.Generic;

using P03.DetailPrinter;

namespace P03.Detail_Printer
{
    public class Mechanic : IEmployee
    {
        public Mechanic(string name, string[] tools)
        {
            this.Name = name;
            this.ToolBox = tools;
        }

        public IReadOnlyCollection<string> ToolBox { get; }

        public string Name { get; }

        public string Details()
        {
            return this.Name +
                Environment.NewLine + "  " +
                string.Join(Environment.NewLine + "  ", this.ToolBox);
        }
    }
}
