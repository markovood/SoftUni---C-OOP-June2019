namespace VehiclesExtension
{
    public class Bus : Vehicle
    {
        private bool isEmpty;

        private double initialFuelConsumption;

        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity) : 
            base(fuelQuantity, fuelConsumption, tankCapacity)
        {
            this.IsEmpty = false;
            this.initialFuelConsumption = fuelConsumption;
        }

        public bool IsEmpty 
        {
            get => this.isEmpty;

            set
            {
                this.isEmpty = value;

                if (value == false)
                {
                    this.FuelConsumption += 1.4;
                }
                else
                {
                    this.FuelConsumption = initialFuelConsumption;
                }
            }
        }
    }
}
