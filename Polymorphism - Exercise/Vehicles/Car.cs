namespace Vehicles
{
    public class Car : Vehicle
    {
        private const double AIRCONDITIONER_INCREASE = 0.9;

        public Car(double fuelQuantity, double fuelConsumption) : 
            base(fuelQuantity, fuelConsumption)
        {
            this.FuelConsumption += AIRCONDITIONER_INCREASE;
        }
    }
}
