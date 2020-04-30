using System;

using CustomTestingFramework.Asserts;
using CustomTestingFramework.Attributes;

namespace CustomTestingFramework.Tests
{
    [TestClass]
    public class MyTestClass
    {
        [TestMethod]
        public void TwoPlusThreeExpectedToBeFive()
        {
            int a = 2;
            int b = 3;

            int actualSum = a + b;
            int expectedSum = 5;

            Assert.AreEqual(actualSum, expectedSum);
        }

        [TestMethod]
        public void TwoPlusThreeExpectedToBeSix()
        {
            int a = 2;
            int b = 3;

            int actualSum = a + b;
            int expectedSum = 6;

            Assert.AreEqual(actualSum, expectedSum);
        }

        [TestMethod]
        public void TwoPlusThreeIsNotExpectedToBeSix()
        {
            int a = 2;
            int b = 3;

            int actualSum = a + b;
            int expectedSum = 6;

            Assert.AreNotEqual(actualSum, expectedSum);
        }

        [TestMethod]
        public void TwoPlusThreeIsNotExpectedToBeFive()
        {
            int a = 2;
            int b = 3;

            int actualSum = a + b;
            int expectedSum = 5;

            Assert.AreNotEqual(actualSum, expectedSum);
        }

        [TestMethod]
        public void TwoDividedByZeroExpectedToBeFive()
        {
            int a = 2;
            int b = 0;

            int actualSum = a / b;
            int expectedSum = 5;

            Assert.AreEqual(actualSum, expectedSum);
        }

        [TestMethod]
        public void ShouldThrowIndexOutOfRangeException()
        {
            var a = new string[5];
            Assert.Throws<IndexOutOfRangeException>(() => a[12] == "Lalala");
        }


    }
}
