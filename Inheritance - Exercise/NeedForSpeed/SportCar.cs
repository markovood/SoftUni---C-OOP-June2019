using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class SportCar : Car
    {
        public SportCar(int horsePower, double fuel) : 
            base(horsePower, fuel)
        {
            this.DefaultFuelConsumption = this.FuelConsumption;
        }

        public override double FuelConsumption => 10.0;
    }
}
