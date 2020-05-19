using System;
using NUnit.Framework;

namespace Chainblock.Tests
{
    [TestFixture]
    public class TransactionTests
    {
        private int id;
        private TransactionStatus status;
        private string from;
        private string to;
        private double amount;
        private Transaction transaction;

        [SetUp]
        public void Setup()
        {
            this.id = 1;
            this.status = TransactionStatus.Successfull;
            this.from = "Gosho";
            this.to = "Pesho";
            this.amount = 750;
            this.transaction = new Transaction(id, status, from, to, amount);
        }

        [Test]
        public void ConstructorShouldSetIdPropertyCorrectly()
        {
            int expectedId = this.id;

            int actualId = this.transaction.Id;

            Assert.AreEqual(expectedId, actualId);
        }

        [Test]
        public void ConstructorShouldSetTransactionStatusPropertyCorrectly()
        {
            TransactionStatus expectedStatus = this.status;

            TransactionStatus actualStatus = this.transaction.Status;

            Assert.AreEqual(expectedStatus, actualStatus);
        }

        [Test]
        public void ConstructorShouldSetFromPropertyCorrectly()
        {
            string expectedFrom = this.from;

            string actualFrom = this.transaction.From;

            Assert.AreEqual(expectedFrom, actualFrom);
        }

        [Test]
        public void ConstructorShouldSetToPropertyCorrectly()
        {
            string expectedTo = this.to;

            string actualTo = this.transaction.To;

            Assert.AreEqual(expectedTo, actualTo);
        }

        [Test]
        public void ConstructorShouldSetAmountPropertyCorrectly()
        {
            double expectedAmount = this.amount;

            double actualAmount = this.transaction.Amount;

            Assert.AreEqual(expectedAmount, actualAmount);
        }

        [Test]
        public void IdShouldThrowArgumentOutOfRangeExceptionWhenSetWithNegativeOrZero()
        {
            int negativeId = -5;

            Assert.Throws<ArgumentOutOfRangeException>(
                () => new Transaction(
                            negativeId, 
                            this.status, 
                            this.from, 
                            this.to,
                            this.amount));
        }

        [Test]
        public void FromShouldThrowArgumentNullExceptionWhenSettingWithNullEmptyOrWhiteSpace()
        {
            string nullFrom = null;

            Assert.Throws<ArgumentNullException>(
                () => new Transaction(this.id, this.status, nullFrom, this.to, this.amount));
        }

        [Test]
        public void ToShouldThrowArgumentNullExceptionWhenSettingWithNullEmptyOrWhiteSpace()
        {
            string nullTo = null;

            Assert.Throws<ArgumentNullException>(
                () => new Transaction(this.id, this.status, this.from, nullTo, this.amount));
        }

        [Test]
        public void AmountShouldThrowArgumentOutfRangeExceptionWhenSetToZeroOrNegative()
        {
            double negativeAmount = -500.50;

            Assert.Throws<ArgumentOutOfRangeException>(
                () => new Transaction(this.id, this.status, this.from, this.to, negativeAmount));
        }

        [Test]
        public void CompareToShouldReturnZeroWhenComparedToTransactionWithTheSameAmount()
        {
            var equalTransaction = new Transaction(5, TransactionStatus.Successfull, "TOA", "ONAA", 750);

            Assert.Zero(this.transaction.CompareTo(equalTransaction));
        }

        [Test]
        public void CompareToShouldReturnNegativeWhenComparedToTransactionWithGreaterAmount()
        {
            var greaterTransaction = new Transaction(5, TransactionStatus.Successfull, "TOA", "ONAA", 1750);

            Assert.Negative(this.transaction.CompareTo(greaterTransaction));
        }

        [Test]
        public void CompareToShouldReturnZeroWhenComparedToTransactionWithLessAmount()
        {
            var smallerTransaction = new Transaction(5, TransactionStatus.Successfull, "TOA", "ONAA", 450);

            Assert.Positive(this.transaction.CompareTo(smallerTransaction));
        }
    }
}
