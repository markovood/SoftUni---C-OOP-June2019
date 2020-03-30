using System;
using MilitaryElite.Contracts;

namespace MilitaryElite.Models
{
    public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        private string corp;

        protected SpecialisedSoldier(int id, string firstName, string lastName, decimal salary, string corp) :
            base(id, firstName, lastName, salary)
        {
            this.Corp = corp;
        }

        public string Corp
        {
            get => this.corp;
            private set
            {
                if (value != "Airforces" && value != "Marines")
                {
                    throw new ArgumentException("Invalid corp!");
                }

                this.corp = value;
            }
        }

        public override string ToString()
        {
            return base.ToString() +
                Environment.NewLine +
                $"Corps: {this.Corp}";
        }
    }
}
