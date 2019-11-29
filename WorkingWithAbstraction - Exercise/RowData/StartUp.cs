using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace RowData
{
    public class StartUp
    {
        public static void Main()
        {
            List<Car> cars = new List<Car>();
            int N = int.Parse(Console.ReadLine());
            for (int i = 0; i < N; i++)
            {
                string[] carInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string model = carInfo[0];
                int speed = int.Parse(carInfo[1]);
                int power = int.Parse(carInfo[2]);
                int weight = int.Parse(carInfo[3]);
                string cargoType = carInfo[4];
                double tire1Pressure = double.Parse(carInfo[5]);
                int tire1Age = int.Parse(carInfo[6]);
                double tire2Pressure = double.Parse(carInfo[7]);
                int tire2Age = int.Parse(carInfo[8]);
                double tire3Pressure = double.Parse(carInfo[9]);
                int tire3Age = int.Parse(carInfo[10]);
                double tire4Pressure = double.Parse(carInfo[11]);
                int tire4Age = int.Parse(carInfo[12]);

                var car = new Car(model, new Engine(speed, power), new Cargo(weight, cargoType), new Tire[]
                {
                    new Tire(tire1Pressure, tire1Age),
                    new Tire(tire2Pressure, tire2Age),
                    new Tire(tire3Pressure, tire3Age),
                    new Tire(tire4Pressure, tire4Age)
                });

                cars.Add(car);
            }

            string command = Console.ReadLine();
            List<Car> filtered = new List<Car>();
            switch (command)
            {
                case "fragile":
                    // print all cars whose cargo is "fragile" with a tire, whose pressure is  < 1
                    filtered = cars
                        .Where(c => c.Cargo.Type == "fragile")
                        .Where(c => c.TiresSet.Any(t => t.Pressure < 1))
                        .ToList();
                    break;
                case "flamable":
                    // print all of the cars, whose cargo is "flamable" and have engine power > 250
                    filtered = cars
                        .Where(c => c.Cargo.Type == "flamable")
                        .Where(e => e.Engine.Power > 250)
                        .ToList();
                    break;
            }


            foreach (var car in filtered)
            {
                Console.WriteLine(car);
            }
        }
    }
}
