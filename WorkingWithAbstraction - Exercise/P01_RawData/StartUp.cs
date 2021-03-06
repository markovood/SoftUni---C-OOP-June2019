﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace P01_RawData
{
    public class StartUp
    {
        public static void Main()
        {
            List<Car> cars = new List<Car>();
            int lines = int.Parse(Console.ReadLine());
            for (int i = 0; i < lines; i++)
            {
                string[] parameters = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string model = parameters[0];
                int engineSpeed = int.Parse(parameters[1]);
                int enginePower = int.Parse(parameters[2]);
                int cargoWeight = int.Parse(parameters[3]);
                string cargoType = parameters[4];
                double tire1Pressure = double.Parse(parameters[5]);
                int tire1age = int.Parse(parameters[6]);
                double tire2Pressure = double.Parse(parameters[7]);
                int tire2age = int.Parse(parameters[8]);
                double tire3Pressure = double.Parse(parameters[9]);
                int tire3age = int.Parse(parameters[10]);
                double tire4Pressure = double.Parse(parameters[11]);
                int tire4age = int.Parse(parameters[12]);

                var engine = new Engine(engineSpeed, enginePower);
                var cargo = new Cargo(cargoWeight, cargoType);
                var tiresSet = new KeyValuePair<double, int>[4] 
                {
                    new KeyValuePair<double, int>( tire1Pressure, tire1age),
                    new KeyValuePair<double, int>( tire2Pressure, tire2age),
                    new KeyValuePair<double, int>( tire3Pressure, tire3age),
                    new KeyValuePair<double, int>( tire4Pressure, tire4age)
                };

                var car = new Car(model, engine, cargo, tiresSet);

                cars.Add(car);
            }

            string command = Console.ReadLine();
            List<Car> filtered = new List<Car>();
            if (command == "fragile")
            {
                filtered = cars
                    .Where(c => c.Cargo.Type == "fragile" && c.TiresSet.Any(t => t.Key < 1))
                    .ToList();
            }
            else
            {
                filtered = cars
                    .Where(c => c.Cargo.Type == "flamable" && c.Engine.Power > 250)
                    .ToList();
            }

            filtered.ForEach(Console.WriteLine);
        }
    }
}
