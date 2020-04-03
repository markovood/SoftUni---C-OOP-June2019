using System;
using ExplicitInterfaces.Contracts;
using ExplicitInterfaces.Models;

namespace ExplicitInterfaces
{
    public class Program
    {
        public static void Main()
        {
            while (true)
            {
                string line = Console.ReadLine();
                if (line == "End")
                {
                    break;
                }

                string[] lineArgs = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                Citizen citizen = new Citizen(lineArgs[0], lineArgs[1], int.Parse(lineArgs[2]));

                IResident resident = citizen;
                IPerson person = citizen;

                Console.WriteLine(citizen.GetName());
                Console.WriteLine(resident.GetName());
            }
        }
    }
}
