using System;
using System.Collections.Generic;

using MilitaryElite.Contracts;
using MilitaryElite.Models;

namespace MilitaryElite
{
    public class Program
    {
        public static void Main()
        {
            List<ISoldier> soldiers = new List<ISoldier>();
            while (true)
            {
                string cmd = Console.ReadLine();
                if (cmd == "End")
                {
                    break;
                }

                string[] cmdArgs = cmd.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                switch (cmdArgs[0])
                {
                    case "Private":
                        var @private = new Private(int.Parse(cmdArgs[1]), cmdArgs[2], cmdArgs[3], decimal.Parse(cmdArgs[4]));
                        soldiers.Add(@private);
                        break;
                    case "LieutenantGeneral":
                        var ltGeneral = new LieutenantGeneral(int.Parse(cmdArgs[1]), cmdArgs[2], cmdArgs[3], decimal.Parse(cmdArgs[4]));
                        for (int i = 5; i < cmdArgs.Length; i++)
                        {
                            int privateId = int.Parse(cmdArgs[i]);
                            ltGeneral.AddPrivate((Private)soldiers.Find(s =>s.GetType().Name == "Private" && s.Id == privateId));
                        }

                        soldiers.Add(ltGeneral);

                        break;
                    case "Engineer":
                        try
                        {
                            var engineer = new Engineer(int.Parse(cmdArgs[1]), cmdArgs[2], cmdArgs[3], decimal.Parse(cmdArgs[4]), cmdArgs[5]);
                            for (int i = 6; i < cmdArgs.Length; i += 2)
                            {
                                var repair = new Repair(cmdArgs[i], int.Parse(cmdArgs[i + 1]));
                                engineer.AddRepair(repair);
                            }

                            soldiers.Add(engineer);
                        }
                        catch (ArgumentException)
                        {
                            continue;
                        }

                        break;
                    case "Commando":
                        try
                        {
                            var comando = new Comando(int.Parse(cmdArgs[1]), cmdArgs[2], cmdArgs[3], decimal.Parse(cmdArgs[4]), cmdArgs[5]);
                            for (int i = 6; i < cmdArgs.Length; i += 2)
                            {
                                try
                                {
                                    var mission = new Mission(cmdArgs[i], cmdArgs[i + 1]);
                                    comando.AddMission(mission);
                                }
                                catch (ArgumentException)
                                {
                                    continue;
                                }
                            }

                            soldiers.Add(comando);
                        }
                        catch (ArgumentException)
                        {
                            continue;
                        }

                        break;
                    case "Spy":
                        var spy = new Spy(int.Parse(cmdArgs[1]), cmdArgs[2], cmdArgs[3], int.Parse(cmdArgs[4]));
                        soldiers.Add(spy);
                        break;
                }
            }

            soldiers.ForEach(s => Console.WriteLine(s));
        }
    }
}
