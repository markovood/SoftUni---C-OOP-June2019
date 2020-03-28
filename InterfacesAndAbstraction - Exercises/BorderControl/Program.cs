using System;
using System.Collections.Generic;

namespace BorderControl
{
    public class Program
    {
        public static void Main()
        {
            List<IIdentifiable> identified = new List<IIdentifiable>();
            while (true)
            {
                string cmd = Console.ReadLine();
                if (cmd == "End")
                {
                    break;
                }

                string[] cmdArgs = cmd.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                switch (cmdArgs.Length)
                {
                    case 2:
                        var robot = new Robot(cmdArgs[0], cmdArgs[1]);
                        identified.Add(robot);
                        break;
                    case 3:
                        var citizen = new Citizen(cmdArgs[0], int.Parse(cmdArgs[1]), cmdArgs[2]);
                        identified.Add(citizen);
                        break;
                }
            }

            List<IIdentifiable> detained = new List<IIdentifiable>();
            string fakeIdEnd = Console.ReadLine();
            identified.ForEach(c => 
            {
                if (c.Id.EndsWith(fakeIdEnd))
                {
                    detained.Add(c);
                }
            });

            detained.ForEach(d => Console.WriteLine(d.Id));
        }
    }
}
