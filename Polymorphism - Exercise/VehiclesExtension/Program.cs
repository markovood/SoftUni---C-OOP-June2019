using System;
using System.Collections.Generic;
using System.Linq;

namespace VehiclesExtension
{
    public class Program
    {
        public static void Main()
        {
            // "Vehicle {initial fuel quantity} {liters per km} {tank capacity}"
            List<Vehicle> vehicles = new List<Vehicle>();
            for (int i = 0; i < 3; i++)
            {
                string[] vehicleInfoArgs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                switch (vehicleInfoArgs[0])
                {
                    case "Car":
                        var car = new Car(double.Parse(vehicleInfoArgs[1]),
                                        double.Parse(vehicleInfoArgs[2]),
                                        double.Parse(vehicleInfoArgs[3]));

                        vehicles.Add(car);
                        break;
                    case "Truck":
                        var truck = new Truck(double.Parse(vehicleInfoArgs[1]),
                                        double.Parse(vehicleInfoArgs[2]),
                                        double.Parse(vehicleInfoArgs[3]));

                        vehicles.Add(truck);
                        break;
                    case "Bus":
                        var bus = new Bus(double.Parse(vehicleInfoArgs[1]),
                                        double.Parse(vehicleInfoArgs[2]),
                                        double.Parse(vehicleInfoArgs[3]));

                        vehicles.Add(bus);
                        break;
                }
            }


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
                            vehicles.First(v => v.GetType().Name == "Car").Drive(distance);
                        }
                        else if (cmdArgs[1] == "Truck")
                        {
                            vehicles.First(v => v.GetType().Name == "Truck").Drive(distance);
                        }
                        else if (cmdArgs[1] == "Bus")
                        {
                            vehicles.First(v => v.GetType().Name == "Bus").Drive(distance);
                        }

                        Console.WriteLine($"{cmdArgs[1]} travelled {distance} km");
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message); ;
                    }
                }
                else if (cmdArgs[0] == "DriveEmpty")
                {
                    try
                    {
                        double distance = double.Parse(cmdArgs[2]);
                        var bus = vehicles.First(v => v.GetType().Name == "Bus") as Bus;
                        bus.IsEmpty = true;
                        bus.Drive(distance);// missing null check for bus

                        Console.WriteLine($"{cmdArgs[1]} travelled {distance} km");
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message); ;
                    }
                }
                else if (cmdArgs[0] == "Refuel")
                {
                    try
                    {
                        double liters = double.Parse(cmdArgs[2]);
                        if (cmdArgs[1] == "Car")
                        {
                            vehicles.First(v => v.GetType().Name == "Car").Refuel(liters);
                        }
                        else if (cmdArgs[1] == "Truck")
                        {
                            vehicles.First(v => v.GetType().Name == "Truck").Refuel(liters);
                        }
                        else if (cmdArgs[1] == "Bus")
                        {
                            vehicles.First(v => v.GetType().Name == "Bus").Refuel(liters);
                        }
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            Console.WriteLine($"Car: {vehicles.First(v => v.GetType().Name == "Car").FuelQuantity:F2}");
            Console.WriteLine($"Truck: {vehicles.First(v => v.GetType().Name == "Truck").FuelQuantity:F2}");
            Console.WriteLine($"Bus: {vehicles.First(v => v.GetType().Name == "Bus").FuelQuantity:F2}");
        }
    }
}
