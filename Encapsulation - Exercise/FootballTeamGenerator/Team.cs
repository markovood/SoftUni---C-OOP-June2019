using System;
using System.Collections.Generic;

namespace FootballTeamGenerator
{
    public class Team
    {
        private string name;
        private List<Player> players;

        public Team(string name)
        {
            this.Name = name;
            this.players = new List<Player>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }

                this.name = value;
            }
        }

        public double Rating
        {
            get
            {
                double rating = 0;

                foreach (var player in players)
                {
                    rating += (player.Endurance +
                                player.Dribble +
                                player.Passing +
                                player.Shooting +
                                player.Sprint) / 5.0;
                }

                return rating;
            }
        }

        public void AddPlayer(Player player)
        {
            if (player != null)
            {
                this.players.Add(player);
            }
        }

        public bool RemovePlayer(string playerName)
        {
            var target = this.players.Find(pl => pl.Name == playerName);
            if (target != null)
            {
                return this.players.Remove(target);
            }

            return false;
        }
    }
}
