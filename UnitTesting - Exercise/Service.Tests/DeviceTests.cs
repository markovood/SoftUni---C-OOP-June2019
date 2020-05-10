using System.Linq;
using NUnit.Framework;
using Service.Models.Devices;
using Service.Models.Parts;

namespace Service.Tests
{
    public class DeviceTests
    {
        private Laptop laptop;
        private PC pc;
        private Phone phone;

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void LaptopConstructorShouldSetMakeToTheGivenMake()
        {
            this.laptop = new Laptop("Asus");
            string expectedMake = "Asus";

            string actualMake = this.laptop.Make;

            Assert.AreEqual(expectedMake, actualMake);
        }

        [Test]
        public void LaptopConstructorShouldInitializePartsCollection()
        {
            this.laptop = new Laptop("Asus");

            Assert.IsNotNull(this.laptop.Parts);
        }

        [Test]
        public void PcConstructorShouldSetMakeToTheGivenMake()
        {
            this.pc = new PC("Asus");
            string expectedMake = "Asus";

            string actualMake = this.pc.Make;

            Assert.AreEqual(expectedMake, actualMake);
        }

        [Test]
        public void PcConstructorShouldInitializePartsCollection()
        {
            this.pc = new PC("Asus");

            Assert.IsNotNull(this.pc.Parts);
        }

        [Test]
        public void PhoneConstructorShouldSetMakeToTheGivenMake()
        {
            this.phone = new Phone("Nexus");
            string expectedMake = "Nexus";

            string actualMake = this.phone.Make;

            Assert.AreEqual(expectedMake, actualMake);
        }

        [Test]
        public void PhoneConstructorShouldInitializePartsCollection()
        {
            this.phone = new Phone("Nexus");

            Assert.IsNotNull(this.phone.Parts);
        }

        [Test]
        public void LaptopMakeShouldThrowArgumentExceptionWhenSettingNullOrEmpty()
        {
            string make = null;

            Assert
                .That(
                () => this.laptop = new Laptop(make),
                Throws
                .ArgumentException
                .With
                .Message
                .EqualTo("Make cannot be null or empty!"));
        }

        [Test]
        public void PcMakeShouldThrowArgumentExceptionWhenSettingNullOrEmpty()
        {
            string make = null;

            Assert
                .That(
                () => this.pc = new PC(make),
                Throws
                .ArgumentException
                .With
                .Message
                .EqualTo("Make cannot be null or empty!"));
        }

        [Test]
        public void PhoneMakeShouldThrowArgumentExceptionWhenSettingNullOrEmpty()
        {
            string make = null;

            Assert
                .That(
                () => this.phone = new Phone(make),
                Throws
                .ArgumentException
                .With
                .Message
                .EqualTo("Make cannot be null or empty!"));
        }

        [Test]
        public void LaptopAddPartShouldThrowInvalidOperationExceptionWhenAddingPartThatIsNotLaptopPart()
        {
            this.laptop = new Laptop("Asus");
            var partToAdd = new PCPart("RAM", 100m);

            Assert
                .That(
                () => this.laptop.AddPart(partToAdd),
                Throws
                .InvalidOperationException
                .With
                .Message
                .Contains("You cannot add "));
        }

        [Test]
        public void PcAddPartShouldThrowInvalidOperationExceptionWhenAddingPartThatIsNotPcPart()
        {
            this.pc = new PC("Asus");
            var partToAdd = new LaptopPart("RAM", 100m);

            Assert
                .That(
                () => this.pc.AddPart(partToAdd),
                Throws
                .InvalidOperationException
                .With
                .Message
                .Contains("You cannot add "));
        }

        [Test]
        public void PhoneAddPartShouldThrowInvalidOperationExceptionWhenAddingPartThatIsNotPhonePart()
        {
            this.phone = new Phone("Nexus");
            var partToAdd = new PCPart("RAM", 100m);

            Assert
                .That(
                () => this.phone.AddPart(partToAdd),
                Throws
                .InvalidOperationException
                .With
                .Message
                .Contains("You cannot add "));
        }

        [Test]
        public void LaptopAddPartShouldThrowInvalidOperationExceptionWhenSamePartAlreadyExists()
        {
            this.laptop = new Laptop("Asus");
            var part = new LaptopPart("RAM", 100m);
            this.laptop.AddPart(part);

            Assert
                .That(
                () => this.laptop.AddPart(part),
                Throws
                .InvalidOperationException
                .With
                .Message
                .EqualTo("This part already exists!"));
        }

        [Test]
        public void PcAddPartShouldThrowInvalidOperationExceptionWhenSamePartAlreadyExists()
        {
            this.pc = new PC("Asus");
            var part = new PCPart("RAM", 100m);
            this.pc.AddPart(part);

            Assert
                .That(
                () => this.pc.AddPart(part),
                Throws
                .InvalidOperationException
                .With
                .Message
                .EqualTo("This part already exists!"));
        }

        [Test]
        public void PhoneAddPartShouldThrowInvalidOperationExceptionWhenSamePartAlreadyExists()
        {
            this.phone = new Phone("Asus");
            var part = new PhonePart("Wi-fi", 100m);
            this.phone.AddPart(part);

            Assert
                .That(
                () => this.phone.AddPart(part),
                Throws
                .InvalidOperationException
                .With
                .Message
                .EqualTo("This part already exists!"));
        }

        [Test]
        public void DeviceRemovePartShouldThrowArgumentExceptionWhenPartToRemoveNameIsNullOrEmpty()
        {
            string partToRemoveName = null;
            var device = new Laptop("Asus");

            Assert
                .That(
                () => device.RemovePart(partToRemoveName),
                Throws
                .ArgumentException
                .With
                .Message
                .EqualTo("Part name cannot be null or empty!"));
        }

        [Test]
        public void DeviceRemovePartShouldThrowInvalidOperationExceptionWhenPartToRemoveIsNotFound()
        {
            var device = new Laptop("Asus");
            var nonExsistingPart = new LaptopPart("RAM", 100m);

            Assert
                .That(
                () => device.RemovePart(nonExsistingPart.Name),
                Throws
                .InvalidOperationException
                .With
                .Message
                .EqualTo("You cannot remove part which does not exist!"));
        }

        [Test]
        public void DeviceRemovePartShouldRemoveThePart()
        {
            var device = new Laptop("Asus");
            var part = new LaptopPart("RAM", 100m);
            device.AddPart(part);

            device.RemovePart(part.Name);

            Assert.IsTrue(device.Parts.FirstOrDefault(p => p.Name == part.Name) == null);
        }

        [Test]
        public void DeviceRepairPartShouldThrowArgumentExceptionWhenPartToRepairNameIsNullOrEmpty()
        {
            string partToRepairName = null;
            var device = new Laptop("Asus");

            Assert
                .That(
                () => device.RepairPart(partToRepairName),
                Throws
                .ArgumentException
                .With
                .Message
                .EqualTo("Part name cannot be null or empty!"));
        }

        [Test]
        public void DeviceRepairPartShouldThrowInvalidOperationExceptionWhenPartToRepairIsNotFound()
        {
            var device = new Laptop("Asus");
            var nonExsistingPart = new LaptopPart("RAM", 100m);

            Assert
                .That(
                () => device.RepairPart(nonExsistingPart.Name),
                Throws
                .InvalidOperationException
                .With
                .Message
                .EqualTo("You cannot repair part which does not exist!"));
        }

        [Test]
        public void DeviceRepairPartShouldThrowInvalidOperationExceptionWhenPartToRepairIsNotBroken()
        {
            var part = new LaptopPart("RAM", 100m);
            var device = new Laptop("Asus");
            device.AddPart(part);

            Assert
                .That(
                () => device.RepairPart(part.Name),
                Throws
                .InvalidOperationException
                .With
                .Message
                .EqualTo("You cannot repair part which is not broken!"));
        }

        [Test]
        public void DeviceRepairPartShoulTurnIsBrokenToFalse()
        {
            var part = new LaptopPart("RAM", 10m, true);
            var device = new Laptop("Asus");
            device.AddPart(part);

            device.RepairPart(part.Name);

            Assert.IsFalse(device.Parts.FirstOrDefault(p => p.Name == part.Name).IsBroken);
        }
    }
}
