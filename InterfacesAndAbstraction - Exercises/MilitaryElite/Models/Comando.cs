using System;
using System.Collections.Generic;
using MilitaryElite.Contracts;

namespace MilitaryElite.Models
{
    public class Comando : SpecialisedSoldier, ICommando
    {
        private List<Mission> missions;

        public Comando(int id, string firstName, string lastName, decimal salary, string corp) :
            base(id, firstName, lastName, salary, corp)
        {
            this.missions = new List<Mission>();
        }

        public IReadOnlyCollection<IMission> Missions => this.missions.AsReadOnly();

        public void AddMission(Mission mission)
        {
            if (mission != null)
            {
                this.missions.Add(mission);
            }
        }

        public override string ToString()
        {
            if (this.missions.Count == 0)
            {
                return base.ToString() + 
                    Environment.NewLine + 
                    "Missions:";
            }

            return base.ToString() +
                Environment.NewLine +
                "Missions:" +
                Environment.NewLine + "  " + 
                string.Join(Environment.NewLine + "  ", this.missions);
        }
    }
}
