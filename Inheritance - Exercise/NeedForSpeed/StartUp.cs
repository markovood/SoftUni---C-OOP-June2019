using System;

namespace NeedForSpeed
{
    public class StartUp
    {
        public static void Main()
        {
            var motor = new Motorcycle(150, 5.0);
            motor.Drive(100);
            Console.WriteLine(motor.FuelConsumption);
            Console.WriteLine(motor.DefaultFuelConsumption);
            Console.WriteLine(motor.Fuel);

            Console.WriteLine(new string('*', 15));
            var raceMotor = new RaceMotorcycle(250, 15.0);
            raceMotor.Drive(100);
            Console.WriteLine(raceMotor.FuelConsumption);
            Console.WriteLine(raceMotor.DefaultFuelConsumption);
            Console.WriteLine(raceMotor.Fuel);
        }
    }
}
