using System;

namespace Vehicles
{
    public abstract class Vehicle
    {
        protected Vehicle(double fuelQuantity, double fuelConsumption)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }

        public double FuelQuantity { get; private set; }

        public double FuelConsumption { get; protected set; }

        public void Drive(double distance)
        {
            double fuelToBeUsed = distance * this.FuelConsumption;
            if (this.FuelQuantity >= fuelToBeUsed)
            {
                this.FuelQuantity -= fuelToBeUsed;
            }
            else
            {
                throw new ArgumentException($"{this.GetType().Name} needs refueling");
            }
        }

        public virtual void Refuel(double liters)
        {
            this.FuelQuantity += liters;
        }
    }
}
