using System;
using System.Collections.Generic;
using MilitaryElite.Contracts;

namespace MilitaryElite.Models
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        private List<Private> privates;

        public LieutenantGeneral(int id, string firstName, string lastName, decimal salary) :
            base(id, firstName, lastName, salary)
        {
            this.privates = new List<Private>();
        }

        public IReadOnlyCollection<IPrivate> Privates { get => this.privates.AsReadOnly(); }

        public void AddPrivate(Private soldier)
        {
            if (soldier != null)
            {
                this.privates.Add(soldier);
            }
        }

        public override string ToString()
        {
            if (this.privates.Count == 0)
            {
                return base.ToString() +
                    Environment.NewLine + 
                    "Privates:";
            }

            return base.ToString() +
                Environment.NewLine + 
                "Privates:" + 
                Environment.NewLine + 
                "  " + string.Join(Environment.NewLine + "  ", this.privates);
        }
    }
}
