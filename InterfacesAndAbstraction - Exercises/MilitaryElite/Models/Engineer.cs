using System;
using System.Collections.Generic;
using MilitaryElite.Contracts;

namespace MilitaryElite.Models
{
    public class Engineer : SpecialisedSoldier, IEngineer
    {
        private List<Repair> repairs;

        public Engineer(int id, string firstName, string lastName, decimal salary, string corp) :
            base(id, firstName, lastName, salary, corp)
        {
            this.repairs = new List<Repair>();
        }

        public IReadOnlyCollection<IRepairable> Repairs => this.repairs.AsReadOnly();

        public void AddRepair(Repair repair)
        {
            if (repair != null)
            {
                this.repairs.Add(repair);
            }
        }

        public override string ToString()
        {
            if (this.repairs.Count == 0)
            {
                return base.ToString() +
                    Environment.NewLine +
                    "Repairs:";
            }

            return base.ToString() +
                Environment.NewLine +
                "Repairs:" +
                Environment.NewLine + "  " +
                string.Join(Environment.NewLine + "  ", this.repairs);
        }
    }
}
