namespace Vehicles
{
    public class Truck : Vehicle
    {
        private const double AIRCONDITIONER_INCREASE = 1.6;

        public Truck(double fuelQuantity, double fuelConsumption) : 
            base(fuelQuantity, fuelConsumption)
        {
            this.FuelConsumption += AIRCONDITIONER_INCREASE;
        }

        public override void Refuel(double liters)
        {
            const double KEPT_FUEL_PERCENT = 0.95;
            base.Refuel(liters * KEPT_FUEL_PERCENT);
        }
    }
}
