using System;
using System.Collections.Generic;

namespace BirthdayCelebrations
{
    public class Program
    {
        public static void Main()
        {
            List<IBirthable> born = new List<IBirthable>();
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
                    case "Robot":
                        break;
                    case "Citizen":
                        var citizen = new Citizen(cmdArgs[1], int.Parse(cmdArgs[2]), cmdArgs[3], cmdArgs[4]);
                        born.Add(citizen);
                        break;
                    case "Pet":
                        var pet = new Pet(cmdArgs[1], cmdArgs[2]);
                        born.Add(pet);
                        break;
                }
            }

            string year = Console.ReadLine();
            born.ForEach(b =>
            {
                if (b.Birthdate.EndsWith(year))
                {
                    Console.WriteLine(b.Birthdate);
                }
            });
        }
    }
}
