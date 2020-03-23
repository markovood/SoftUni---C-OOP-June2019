using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public abstract class Vehicle
    {
        public Vehicle(int horsePower, double fuel)
        {
            this.HorsePower = horsePower;
            this.Fuel = fuel;
            this.DefaultFuelConsumption = 1.25;
            //this.FuelConsumption = this.DefaultFuelConsumption;
        }

        public double DefaultFuelConsumption { get; protected set; }

        public virtual double FuelConsumption { get; private set; }

        public double Fuel { get; private set; }

        public int HorsePower { get; }

        public virtual void Drive(double kilometers)
        {
            // The Drive method should have a functionality to reduce the Fuel based on the traveled kilometers.
            this.Fuel -= kilometers * this.FuelConsumption;
        }
    }
}
