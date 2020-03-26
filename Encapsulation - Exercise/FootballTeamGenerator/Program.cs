using System;
using System.Collections.Generic;

namespace FootballTeamGenerator
{
    public class Program
    {
        public static void Main()
        {
            List<Team> teams = new List<Team>();
            while (true)
            {
                string cmd = Console.ReadLine();
                if (cmd == "END")
                {
                    break;
                }

                string[] cmdArgs = cmd.Split(';', StringSplitOptions.RemoveEmptyEntries);
                try
                {
                    switch (cmdArgs[0])
                    {
                        case "Team":
                            var team = new Team(cmdArgs[1]);
                            if (!teams.Exists(t => t.Name == team.Name))
                            {
                                teams.Add(team);
                            }

                            break;
                        case "Add":
                            var targetTeam = teams.Find(t => t.Name == cmdArgs[1]);
                            if (targetTeam != null)
                            {
                                var player = new Player(cmdArgs[2],
                                                    int.Parse(cmdArgs[3]),
                                                    int.Parse(cmdArgs[4]),
                                                    int.Parse(cmdArgs[5]),
                                                    int.Parse(cmdArgs[6]),
                                                    int.Parse(cmdArgs[7]));

                                targetTeam.AddPlayer(player);
                            }
                            else
                            {
                                Console.WriteLine($"Team {cmdArgs[1]} does not exist.");
                            }

                            break;
                        case "Remove":
                            targetTeam = teams.Find(t => t.Name == cmdArgs[1]);
                            if (targetTeam != null)
                            {
                                bool removed = targetTeam.RemovePlayer(cmdArgs[2]);
                                if (!removed)
                                {
                                    Console.WriteLine($"Player {cmdArgs[2]} is not in {targetTeam.Name} team.");
                                }
                            }
                            else
                            {
                                Console.WriteLine($"Team {cmdArgs[1]} does not exist.");
                            }

                            break;
                        case "Rating":
                            team = teams.Find(t => t.Name == cmdArgs[1]);
                            if (team != null)
                            {
                                Console.WriteLine($"{team.Name} - {team.Rating:F0}");
                            }
                            else
                            {
                                Console.WriteLine($"Team {cmdArgs[1]} does not exist.");
                            }

                            break;
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
