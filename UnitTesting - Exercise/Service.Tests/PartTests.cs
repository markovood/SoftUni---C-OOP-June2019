using NUnit.Framework;
using Service.Models.Parts;

namespace Tests
{
    public class PartTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void LaptopPartConstructorWithTwoParametersShouldSetNameCorrectly()
        {
            var laptopPart = new LaptopPart("Ram", 100m);
            string expectedName = "Ram";

            string actualName = laptopPart.Name;

            Assert.AreEqual(expectedName, actualName);
        }

        [Test]
        public void LaptopPartConstructorWithThreeParametersShouldSetNameCorrectly()
        {
            var laptopPart = new LaptopPart("Ram", 100m, true);
            string expectedName = "Ram";

            string actualName = laptopPart.Name;

            Assert.AreEqual(expectedName, actualName);
        }

        [Test]
        public void PCPartConstructorWithTwoParametersShouldSetNameCorrectly()
        {
            var PCPart = new PCPart("Ram", 100m);
            string expectedName = "Ram";

            string actualName = PCPart.Name;

            Assert.AreEqual(expectedName, actualName);
        }

        [Test]
        public void PCPartConstructorWithThreeParametersShouldSetNameCorrectly()
        {
            var PCPart = new PCPart("Ram", 100m, true);
            string expectedName = "Ram";

            string actualName = PCPart.Name;

            Assert.AreEqual(expectedName, actualName);
        }

        [Test]
        public void PhonePartConstructorWithTwoParametersShouldSetNameCorrectly()
        {
            var PhonePart = new PhonePart("Ram", 100m);
            string expectedName = "Ram";

            string actualName = PhonePart.Name;

            Assert.AreEqual(expectedName, actualName);
        }

        [Test]
        public void PhonePartConstructorWithThreeParametersShouldSetNameCorrectly()
        {
            var PhonePart = new PhonePart("Ram", 100m, true);
            string expectedName = "Ram";

            string actualName = PhonePart.Name;

            Assert.AreEqual(expectedName, actualName);
        }

        [Test]
        public void LaptopPartConstructorWithTwoParametersShouldSetCostCorrectly()
        {
            var laptopPart = new LaptopPart("ram", 100m);
            decimal expectedCost = 100m * 1.5m;

            decimal actualCost = laptopPart.Cost;

            Assert.AreEqual(expectedCost, actualCost);
        }

        [Test]
        public void LaptopPartConstructorWithThreeParametersShouldSetCostCorrectly()
        {
            var laptopPart = new LaptopPart("ram", 100m, true);
            decimal expectedCost = 100m * 1.5m;

            decimal actualCost = laptopPart.Cost;

            Assert.AreEqual(expectedCost, actualCost);
        }

        [Test]
        public void PCPartConstructorWithTwoParametersShouldSetCostCorrectly()
        {
            var PCPart = new PCPart("ram", 100m);
            decimal expectedCost = 100m * 1.2m;

            decimal actualCost = PCPart.Cost;

            Assert.AreEqual(expectedCost, actualCost);
        }

        [Test]
        public void PCPartConstructorWithThreeParametersShouldSetCostCorrectly()
        {
            var PCPart = new PCPart("ram", 100m, true);
            decimal expectedCost = 100m * 1.2m;

            decimal actualCost = PCPart.Cost;

            Assert.AreEqual(expectedCost, actualCost);
        }

        [Test]
        public void PhonePartConstructorWithTwoParametersShouldSetCostCorrectly()
        {
            var PhonePart = new PhonePart("ram", 100m);
            decimal expectedCost = 100m * 1.3m;

            decimal actualCost = PhonePart.Cost;

            Assert.AreEqual(expectedCost, actualCost);
        }

        [Test]
        public void PhonePartConstructorWithThreeParametersShouldSetCostCorrectly()
        {
            var PhonePart = new PhonePart("ram", 100m, true);
            decimal expectedCost = 100m * 1.3m;

            decimal actualCost = PhonePart.Cost;

            Assert.AreEqual(expectedCost, actualCost);
        }

        [Test]
        public void LaptopPartConstructorWithTwoParametersShouldSetIsBrokenCorrectly()
        {
            var laptopPart = new LaptopPart("ram", 100m);

            bool actualIsBroken = laptopPart.IsBroken;

            Assert.IsFalse(actualIsBroken);
        }

        [Test]
        public void LaptopPartConstructorWithThreeParametersShouldSetIsBrokenCorrectly()
        {
            var laptopPart = new LaptopPart("ram", 100m, true);

            bool actualIsBroken = laptopPart.IsBroken;

            Assert.IsTrue(actualIsBroken);
        }

        [Test]
        public void PCPartConstructorWithTwoParametersShouldSetIsBrokenCorrectly()
        {
            var PCPart = new PCPart("ram", 100m);

            bool actualIsBroken = PCPart.IsBroken;

            Assert.IsFalse(actualIsBroken);
        }

        [Test]
        public void PCPartConstructorWithThreeParametersShouldSetIsBrokenCorrectly()
        {
            var PCPart = new PCPart("ram", 100m, true);

            bool actualIsBroken = PCPart.IsBroken;

            Assert.IsTrue(actualIsBroken);
        }

        [Test]
        public void PhonePartConstructorWithTwoParametersShouldSetIsBrokenCorrectly()
        {
            var PhonePart = new PhonePart("ram", 100m);

            bool actualIsBroken = PhonePart.IsBroken;

            Assert.IsFalse(actualIsBroken);
        }

        [Test]
        public void PhonePartConstructorWithThreeParametersShouldSetIsBrokenCorrectly()
        {
            var PhonePart = new PhonePart("ram", 100m, true);

            bool actualIsBroken = PhonePart.IsBroken;

            Assert.IsTrue(actualIsBroken);
        }

        [Test]
        public void LaptopPartNameShouldThrowArgumentExceptionWhenSettingWithNullOrEmpty()
        {
            Assert
                .That(
                () => new LaptopPart(null, 100m),
                Throws
                .ArgumentException
                .With
                .Message
                .EqualTo("Part name cannot be null or empty!"));
        }

        [Test]
        public void PCPartNameShouldThrowArgumentExceptionWhenSettingWithNullOrEmpty()
        {
            Assert
                .That(
                () => new PCPart(null, 100m),
                Throws
                .ArgumentException
                .With
                .Message
                .EqualTo("Part name cannot be null or empty!"));
        }

        [Test]
        public void PhonePartNameShouldThrowArgumentExceptionWhenSettingWithNullOrEmpty()
        {
            Assert
                .That(
                () => new PhonePart(null, 100m),
                Throws
                .ArgumentException
                .With
                .Message
                .EqualTo("Part name cannot be null or empty!"));
        }

        [Test]
        public void LaptopPartCostShouldThrowArgumentExceptionWhenSettingWithZeroOrNegative()
        {
            Assert
                .That(
                () => new LaptopPart("ram", -5),
                Throws
                .ArgumentException
                .With
                .Message
                .EqualTo("Part cost cannot be zero or negative!"));
        }

        [Test]
        public void PCPartCostShouldThrowArgumentExceptionWhenSettingWithZeroOrNegative()
        {
            Assert
                .That(
                () => new PCPart("ram", -5),
                Throws
                .ArgumentException
                .With
                .Message
                .EqualTo("Part cost cannot be zero or negative!"));
        }

        [Test]
        public void PhonePartCostShouldThrowArgumentExceptionWhenSettingWithZeroOrNegative()
        {
            Assert
                .That(
                () => new PhonePart("ram", -5),
                Throws
                .ArgumentException
                .With
                .Message
                .EqualTo("Part cost cannot be zero or negative!"));
        }

        [Test]
        public void LaptopPartRepairShouldTurnIsBrokenToFalse()
        {
            var laptopPart = new LaptopPart("ram", 100m, true);

            laptopPart.Repair();

            Assert.IsFalse(laptopPart.IsBroken);
        }

        [Test]
        public void PCPartRepairShouldTurnIsBrokenToFalse()
        {
            var PCPart = new PCPart("ram", 100m, true);

            PCPart.Repair();

            Assert.IsFalse(PCPart.IsBroken);
        }

        [Test]
        public void PhonePartRepairShouldTurnIsBrokenToFalse()
        {
            var phonePart = new PhonePart("ram", 100m, true);

            phonePart.Repair();

            Assert.IsFalse(phonePart.IsBroken);
        }

        [Test]
        public void LaptopPartReportShouldReturnStringContainingNameCostAndIsBrokenPropertiesAsPartOfIt()
        {
            var laptopPart = new LaptopPart("ram", 100m, true);

            StringAssert.Contains($"{laptopPart.Name}", laptopPart.Report(), "Report string doesn't contain Name property");
            StringAssert.Contains($"{laptopPart.Cost}", laptopPart.Report(), "Report string doesn't contain Cost property");
            StringAssert.Contains($"{laptopPart.IsBroken}", laptopPart.Report(), "Report string doesn't contain IsBroken property");
        }

        [Test]
        public void PCPartReportShouldReturnStringContainingNameCostAndIsBrokenPropertiesAsPartOfIt()
        {
            var pcPart = new PCPart("ram", 100m, true);

            StringAssert.Contains($"{pcPart.Name}", pcPart.Report(), "Report string doesn't contain Name property");
            StringAssert.Contains($"{pcPart.Cost}", pcPart.Report(), "Report string doesn't contain Cost property");
            StringAssert.Contains($"{pcPart.IsBroken}", pcPart.Report(), "Report string doesn't contain IsBroken property");
        }

        [Test]
        public void PhonePartReportShouldReturnStringContainingNameCostAndIsBrokenPropertiesAsPartOfIt()
        {
            var phonePart = new PhonePart("ram", 100m, true);

            StringAssert.Contains($"{phonePart.Name}", phonePart.Report(), "Report string doesn't contain Name property");
            StringAssert.Contains($"{phonePart.Cost}", phonePart.Report(), "Report string doesn't contain Cost property");
            StringAssert.Contains($"{phonePart.IsBroken}", phonePart.Report(), "Report string doesn't contain IsBroken property");
        }
    }
}