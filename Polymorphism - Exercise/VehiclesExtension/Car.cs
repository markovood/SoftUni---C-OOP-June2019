namespace VehiclesExtension
{
    public class Car : Vehicle
    {
        private const double AIRCONDITIONER_INCREASE = 0.9;

        public Car(double fuelQuantity, double fuelConsumption, double tankCapacity) :
            base(fuelQuantity, fuelConsumption, tankCapacity)
        {
            this.FuelConsumption += AIRCONDITIONER_INCREASE;
        }
    }
}
