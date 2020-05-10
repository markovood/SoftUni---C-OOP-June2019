using CarManager;

using NUnit.Framework;

namespace Tests
{
    public class CarTests
    {
        private string make;
        private string model;
        private double fuelConsumption;
        private double fuelCapacity;
        private Car car;

        [SetUp]
        public void Setup()
        {
            this.make = "Opel";
            this.model = "Meriva";
            this.fuelConsumption = 6.5;
            this.fuelCapacity = 65.0;

            CreateCar(this.make, this.model, this.fuelConsumption, this.fuelCapacity);
        }

        [Test]
        public void ConstructorShouldSetMakePropertyCorrectly()
        {
            Assert.That(this.car.Make, Is.EqualTo(this.make));
        }
        
        [Test]
        public void ConstructorShouldSetModelPropertyCorrectly()
        {
            Assert.That(this.car.Model, Is.EqualTo(this.model));
        }
        
        [Test]
        public void ConstructorShouldSetFuelConsumptionPropertyCorrectly()
        {
            Assert.That(this.car.FuelConsumption, Is.EqualTo(this.fuelConsumption));
        }
        
        [Test]
        public void ConstructorShouldSetFuelCapacityPropertyCorrectly()
        {
            Assert.That(this.car.FuelCapacity, Is.EqualTo(this.fuelCapacity));
        }

        [Test]
        public void ConstructorShouldSetFuelAmountToZero()
        {
            Assert.That(this.car.FuelAmount, Is.EqualTo(0));
        }

        [Test]
        public void MakeShouldReturnCorrectMake()
        {
            string expectedMake = this.make;

            string actualMake = this.car.Make;

            Assert.AreEqual(expectedMake, actualMake);
        }

        [Test]
        public void MakeShouldThrowArgumentExceptionWhenSettingNullOrEmpty()
        {
            string make = null;

            Assert
                .That(
                () => this.CreateCar(make, this.model, this.fuelConsumption, this.fuelCapacity),
                Throws
                .ArgumentException
                .With
                .Message
                .EqualTo("Make cannot be null or empty!"));
        }
        
        [Test]
        public void ModelShouldReturnCorrectModel()
        {
            string expectedModel = this.model;

            string actualModel = this.car.Model;

            Assert.AreEqual(expectedModel, actualModel);
        }

        [Test]
        public void ModelShouldThrowArgumentExceptionWhenSettingNullOrEmpty()
        {
            string model = null;

            Assert
                .That(
                () => this.CreateCar(this.make, model, this.fuelConsumption, this.fuelCapacity),
                Throws
                .ArgumentException
                .With
                .Message
                .EqualTo("Model cannot be null or empty!"));
        }
        
        [Test]
        public void FuelConsumptionShouldReturnCorrectFuelConsumption()
        {
            double expectedFuelConsumption = this.fuelConsumption;

            double actualFuelConsumption = this.car.FuelConsumption;

            Assert.AreEqual(expectedFuelConsumption, actualFuelConsumption);
        }

        [Test]
        public void FuelConsumptionShouldThrowArgumentExceptionWhenSettingZeroOrNegative()
        {
            double fuelConsumption = 0;

            Assert
                .That(
                () => this.CreateCar(this.make, this.model, fuelConsumption, this.fuelCapacity),
                Throws
                .ArgumentException
                .With
                .Message
                .EqualTo("Fuel consumption cannot be zero or negative!"));
        }
        
        [Test]
        public void FuelCapacityShouldReturnCorrectFuelCapacity()
        {
            double expectedFuelCapacity = this.fuelCapacity;

            double actualFuelCapacity = this.car.FuelCapacity;

            Assert.AreEqual(expectedFuelCapacity, actualFuelCapacity);
        }

        [Test]
        public void FuelCapacityShouldThrowArgumentExceptionWhenSettingZeroOrNegative()
        {
            double fuelCapacity = 0;

            Assert
                .That(
                () => this.CreateCar(this.make, this.model, this.fuelConsumption, fuelCapacity),
                Throws
                .ArgumentException
                .With
                .Message
                .EqualTo("Fuel capacity cannot be zero or negative!"));
        }

        [Test]
        public void FuelAmountShouldReturnCorrectFuelAmount()
        {
            double expectedFuelAmount = 0;

            Assert.AreEqual(expectedFuelAmount, this.car.FuelAmount);
        }

        [Test]
        public void RefuelShouldThrowArgumentExceptionWhenAddingZeroOrNegativeQuantity()
        {
            double amountToAdd = -5d;

            Assert
                .That(
                () => this.car.Refuel(amountToAdd),
                Throws
                .ArgumentException
                .With
                .Message
                .EqualTo("Fuel amount cannot be zero or negative!"));
        }

        [Test]
        public void RefuelShouldAddMaximumUpToFuelCapacity()
        {
            double amountToRefuel = 66d;
            double expectedAmount = this.fuelCapacity;

            this.car.Refuel(amountToRefuel);
            double actualAmount = this.car.FuelAmount;

            Assert.AreEqual(expectedAmount, actualAmount);
        }

        [Test]
        public void DriveShouldReduceFuelAmountAccordingToDistance()
        {
            this.car.Refuel(5);
            double distanceToDrive = 50;
            double fuelNeeded = (distanceToDrive / 100) * this.fuelConsumption;
            double expectedFuelAmount = this.car.FuelAmount - fuelNeeded;

            this.car.Drive(distanceToDrive);

            Assert.AreEqual(expectedFuelAmount, this.car.FuelAmount);
        }

        [Test]
        public void DriveShouldThrowInvalidOperationExceptionWhenFuelNeededToPassDistanceExceedsCurrentFuelAmount()
        {
            this.car.Refuel(5);
            double distanceToDrive = 100;

            Assert
                .That(
                () => this.car.Drive(distanceToDrive),
                Throws
                .InvalidOperationException
                .With
                .Message
                .EqualTo("You don't have enough fuel to drive!"));
        }

        private void CreateCar(string make,string model, double fuelConsumption, double fuelCapacity)
        {
            this.car = new Car(make, model, fuelConsumption, fuelCapacity);
        }
    }
}