namespace VehiclesExtension
{
    public class Truck : Vehicle
    {
        private const double AIRCONDITIONER_INCREASE = 1.6;

        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity) :
            base(fuelQuantity, fuelConsumption, tankCapacity)
        {
            this.FuelConsumption += AIRCONDITIONER_INCREASE;
        }

        public override void Refuel(double liters)
        {
            base.Refuel(liters);
            this.FuelQuantity -= liters * 0.05;
        }
    }
}