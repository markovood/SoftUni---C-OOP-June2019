using System;

namespace Vehicles
{
    public class Program
    {
        public static void Main()
        {
            // "Car {fuel quantity} {liters per km}"
            string[] carInfoArgs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var car = new Car(double.Parse(carInfoArgs[1]), double.Parse(carInfoArgs[2]));

            // "Truck {fuel quantity} {liters per km}"
            string[] truckInfoArgs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var truck = new Truck(double.Parse(truckInfoArgs[1]), double.Parse(truckInfoArgs[2]));

            int N = int.Parse(Console.ReadLine());
            for (int i = 0; i < N; i++)
            {
                // read cmds
                string[] cmdArgs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (cmdArgs[0] == "Drive")
                {
                    try
                    {
                        double distance = double.Parse(cmdArgs[2]);
                        if (cmdArgs[1] == "Car")
                        {
                            car.Drive(distance);
                        }
                        else if (cmdArgs[1] == "Truck")
                        {
                            truck.Drive(distance);
                        }

                        Console.WriteLine($"{cmdArgs[1]} travelled {distance} km");
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message); ;
                    }
                }
                else if (cmdArgs[0] == "Refuel")
                {
                    double liters = double.Parse(cmdArgs[2]);
                    if (cmdArgs[1] == "Car")
                    {
                        car.Refuel(liters);
                    }
                    else if (cmdArgs[1] == "Truck")
                    {
                        truck.Refuel(liters);
                    }
                }
            }

            Console.WriteLine($"Car: {car.FuelQuantity:F2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:F2}");
        }
    }
}
