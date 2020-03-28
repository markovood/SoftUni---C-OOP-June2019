using System;
using System.Collections.Generic;

namespace FoodShortage
{
    public class Program
    {
        public static void Main()
        {
            List<IIdentifyableBuyer> buyers = new List<IIdentifyableBuyer>();

            int numbOfPeople = int.Parse(Console.ReadLine());
            for (int i = 0; i < numbOfPeople; i++)
            {
                string[] cmdArgs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                switch (cmdArgs.Length)
                {
                    case 3:
                        var rebel = new Rebel(cmdArgs[0], int.Parse(cmdArgs[1]), cmdArgs[2]);
                        buyers.Add(rebel);
                        break;
                    case 4:
                        var citizen = new Citizen(cmdArgs[0], int.Parse(cmdArgs[1]), cmdArgs[2], cmdArgs[3]);
                        buyers.Add(citizen);
                        break;
                }
            }

            int totalFood = 0;
            while (true)
            {
                string cmd = Console.ReadLine();
                if (cmd == "End")
                {
                    break;
                }

                string name = cmd;
                var buyer = buyers.Find(b => b.Name == name);
                if (buyer != null)
                {
                    totalFood += buyer.BuyFood();
                }
            }

            Console.WriteLine(totalFood);
        }
    }
}
