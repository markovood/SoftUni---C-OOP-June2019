using System;

namespace VehiclesExtension
{
    public abstract class Vehicle
    {
        private double fuelQuantity;

        protected Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            this.TankCapacity = tankCapacity;
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }

        public double TankCapacity { get; private set; }

        public double FuelQuantity
        {
            get => this.fuelQuantity;
            protected set
            {
                if (value > this.TankCapacity)
                {
                    this.fuelQuantity = 0;
                }
                else
                {
                    this.fuelQuantity = value; 
                }
            }
        }

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
            if (liters <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }

            if (liters > this.TankCapacity - this.FuelQuantity)
            {
                throw new ArgumentException($"Cannot fit {liters} fuel in the tank");
            }

            this.FuelQuantity += liters;
        }
    }
}