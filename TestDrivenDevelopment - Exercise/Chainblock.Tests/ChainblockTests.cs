using System;
using System.Collections.Generic;
using System.Linq;
using Chainblock.Contracts;
using NUnit.Framework;

namespace Chainblock.Tests
{
    [TestFixture]
    public class ChainblockTests
    {
        private Transaction transaction;
        private Chainblock chainblock;

        [SetUp]
        public void Setup()
        {
            this.transaction = new Transaction(
                1,
                TransactionStatus.Successfull,
                "Gosho",
                "Pesho",
                1500);

            this.chainblock = new Chainblock();
            this.chainblock.Add(this.transaction);
        }

        [Test]
        public void CountShouldReturnCorrectNumberOfTransactions()
        {
            int expectedCount = 1;

            int actualCount = this.chainblock.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void GetEnumeratorShouldReturnEveryElementInTheChainblock()
        {
            var transaction = new Transaction(
                2,
                TransactionStatus.Successfull,
                "Gosho",
                "Dancho",
                700);
            this.chainblock.Add(transaction);

            var otherTransaction = new Transaction(
                3,
                TransactionStatus.Successfull,
                "Gosho",
                "Stamat",
                500);
            this.chainblock.Add(otherTransaction);

            var expectedReceivers = new List<string>()
            {
                this.transaction.To,
                transaction.To,
                otherTransaction.To
            };

            var actualReceivers = new List<string>();
            foreach (var tr in this.chainblock)
            {
                actualReceivers.Add(tr.To);
            }

            CollectionAssert.AreEqual(expectedReceivers, actualReceivers);
        }

        [Test]
        public void AddShouldAddTransaction()
        {
            var expectedTransaction = this.transaction;

            CollectionAssert.Contains(this.chainblock, expectedTransaction);
        }

        [Test]
        public void AddShouldThrowArgumentNullExceptionWhenAddingNullTransaction()
        {
            ITransaction transaction = null;

            Assert.Throws<ArgumentNullException>(() => this.chainblock.Add(transaction));
        }

        [Test]
        public void AddShouldThrowInvalidOperationExceptionWhenAddingTransactionWithExistingId()
        {
            Assert
                .That(
                () => this.chainblock.Add(this.transaction),
                Throws
                .InvalidOperationException
                .With
                .Message
                .EqualTo("Cannot add transaction with already existing ID!"));
        }

        [Test]
        public void ContainsShouldReturnTrueWhenTransactionIsExisting()
        {
            Assert.IsTrue(this.chainblock.Contains(this.transaction));
        }

        [Test]
        public void ContainsShouldReturnFalseWhenTransactionIsNotExisting()
        {
            var transaction = new Transaction(15, TransactionStatus.Successfull, "Pesho", "Stamat", 250);

            Assert.IsFalse(this.chainblock.Contains(transaction));
        }

        [Test]
        public void ContainsShouldThrowArgumentNullExceptionWhenLookingForNullTransaction()
        {
            Assert.Throws<ArgumentNullException>(
                () => this.chainblock.Contains(null));
        }

        [Test]
        public void ContainsShouldReturnTrueWhenTransactionWithGivenIdExists()
        {
            Assert.IsTrue(this.chainblock.Contains(1));
        }

        [Test]
        public void ContainsShouldReturnFalseWhenTransactionWithGivenIdIsNotPresent()
        {
            Assert.IsFalse(this.chainblock.Contains(10));
        }

        [Test]
        public void ContainsShouldThrowArgumentOutOfRangeExceptionWhenLookingForNegativeId()
        {
            Assert.Throws<ArgumentOutOfRangeException>(
                () => this.chainblock.Contains(-1));
        }

        [Test]
        public void ChangeTransactionStatusShouldThrowArgumentExceptionWhenNoSuchTransactionExists()
        {
            Assert.Throws<ArgumentException>(
                () => this.chainblock.ChangeTransactionStatus(10, TransactionStatus.Aborted));
        }

        [Test]
        public void ChangeTransactionStatusShouldThrowArgumentOutOfRangeExceptionWhenNegativeIdPassed()
        {
            Assert.Throws<ArgumentOutOfRangeException>(
                () => this.chainblock.ChangeTransactionStatus(-1, TransactionStatus.Aborted));
        }

        [Test]
        public void ChangeTransactionStatusShouldChangeTheStatus()
        {
            TransactionStatus expectedStatus = TransactionStatus.Aborted;

            this.chainblock.ChangeTransactionStatus(1, TransactionStatus.Aborted);
            TransactionStatus actualStatus = this.chainblock
                                                    .First(tr => tr.Id == 1)
                                                    .Status;

            Assert.AreEqual(expectedStatus, actualStatus);
        }

        [Test]
        public void RemoveTransactionByIdShouldThrowInvalidOperationExceptionWhenNoSuchId()
        {
            Assert.Throws<InvalidOperationException>(
                () => this.chainblock.RemoveTransactionById(5));
        }

        [Test]
        public void RemoveTransactionByIdShouldRemoveTransactionWithTheGivenId()
        {
            this.chainblock.RemoveTransactionById(1);

            Assert.IsNull(this.chainblock.FirstOrDefault(tr => tr.Id == 1));
        }

        [Test]
        public void GetByIdShouldThrowInvalidOperationExceptionWhenNoTransactionWithGivenId()
        {
            Assert.Throws<InvalidOperationException>(
                () => this.chainblock.GetById(5));
        }

        [Test]
        public void GetByIdShouldReturnTheTransactionWithTheGivenId()
        {
            var expectedTransaction = this.transaction;

            var actualTransaction = this.chainblock.GetById(1);

            Assert.AreEqual(expectedTransaction, actualTransaction);
        }

        [Test]
        public void GetByTransactionStatusShouldThrowInvalidOperationExceptionWhenNoTransactionsWithTheGivenStatus()
        {
            Assert
                .That(
                () => this.chainblock.GetByTransactionStatus(TransactionStatus.Failed),
                Throws
                .InvalidOperationException
                .With
                .Message
                .EqualTo("No transactions with given status!"));
        }

        [Test]
        public void GetByTransactionStatusShouldReturnAllTransactionsWithTheGivenStatusOrderedByAmountDescending()
        {
            var otherTransaction = new Transaction(2, TransactionStatus.Successfull, "Gosho", "Johnny", 150);
            this.chainblock.Add(otherTransaction);
            var anotherTransaction = new Transaction(3, TransactionStatus.Successfull, "Gosho", "Vankata", 250);
            this.chainblock.Add(anotherTransaction);
            TransactionStatus statusToGet = TransactionStatus.Successfull;
            var expectedCollection = new List<ITransaction>()
            {
                this.transaction,
                anotherTransaction,
                otherTransaction
            };

            var actualCollection = this.chainblock.GetByTransactionStatus(statusToGet);

            CollectionAssert.AreEqual(expectedCollection, actualCollection);
        }

        [Test]
        public void GetAllSendersWithTransactionStatusShouldThrowInvalidOperationExceptionWhenNoSuchTransactionStatusExist()
        {
            Assert
                .That(
                () => this.chainblock.GetAllSendersWithTransactionStatus(TransactionStatus.Failed),
                Throws
                .InvalidOperationException
                .With
                .Message
                .EqualTo("No such transaction status!"));
        }

        [Test]
        public void GetAllSendersWithTransactionStatusShouldReturnAllSendersWithTransactionsWithGivenStatusOrderedByAmount()
        {
            var otherTransaction = new Transaction(2, TransactionStatus.Successfull, "Svetlio", "Johnny", 5000);
            this.chainblock.Add(otherTransaction);
            var anotherTransaction = new Transaction(3, TransactionStatus.Successfull, "Svetlio", "Vankata", 6000);
            this.chainblock.Add(anotherTransaction);
            var abortedTransaction = new Transaction(4, TransactionStatus.Aborted, "Svetlio", "Vankata", 600);
            this.chainblock.Add(abortedTransaction);

            var expectedCollection = new List<string>()
            {
                anotherTransaction.From,
                otherTransaction.From,
                this.transaction.From
            };

            var actualCollection = this.chainblock  
                    .GetAllSendersWithTransactionStatus(TransactionStatus.Successfull);

            CollectionAssert.AreEqual(expectedCollection, actualCollection);
        }

        [Test]
        public void GetAllReceiversWithTransactionStatusShouldThrowInvalidOperationExceptionWhenNoSuchTransactionStatusExist()
        {
            Assert
                .That(
                () => this.chainblock.GetAllReceiversWithTransactionStatus(TransactionStatus.Failed),
                Throws
                .InvalidOperationException
                .With
                .Message
                .EqualTo("No such transaction status!"));
        }

        [Test]
        public void GetAllReceiversWithTransactionStatusShouldReturnAllReceiversWithTransactionsWithGivenStatusOrderedByAmount()
        {
            var otherTransaction = new Transaction(2, TransactionStatus.Successfull, "Svetlio", "Johnny", 5000);
            this.chainblock.Add(otherTransaction);
            var anotherTransaction = new Transaction(3, TransactionStatus.Successfull, "Svetlio", "Vankata", 6000);
            this.chainblock.Add(anotherTransaction);
            var abortedTransaction = new Transaction(4, TransactionStatus.Aborted, "Svetlio", "Vankata", 600);
            this.chainblock.Add(abortedTransaction);

            var expectedCollection = new List<string>()
            {
                anotherTransaction.To,
                otherTransaction.To,
                this.transaction.To
            };

            var actualCollection = this.chainblock
                    .GetAllReceiversWithTransactionStatus(TransactionStatus.Successfull);

            CollectionAssert.AreEqual(expectedCollection, actualCollection);
        }

        [Test]
        public void GetAllOrderedByAmountDescendingThenByIdShouldReturnCorrectCollection()
        {
            var otherTransaction = new Transaction(2, TransactionStatus.Successfull, "Svetlio", "Johnny", 5000);
            this.chainblock.Add(otherTransaction);
            var anotherTransaction = new Transaction(3, TransactionStatus.Successfull, "Svetlio", "Vankata", 6000);
            this.chainblock.Add(anotherTransaction);
            var abortedTransaction = new Transaction(4, TransactionStatus.Aborted, "Svetlio", "Vankata", 6000);
            this.chainblock.Add(abortedTransaction);

            var expectedCollection = new List<ITransaction>()
            {
                anotherTransaction,
                abortedTransaction,
                otherTransaction,
                this.transaction
            };

            var actualCollection = this.chainblock
                        .GetAllOrderedByAmountDescendingThenById();

            CollectionAssert.AreEqual(expectedCollection, actualCollection);
        }

        [Test]
        public void GetBySenderOrderedByAmountDescendingShouldThrowInvalidOperationExceptionWhenNoTransactionsWithGivenSender()
        {
            Assert
                .That(
                () => this.chainblock.GetBySenderOrderedByAmountDescending("Mario"),
                Throws
                .InvalidOperationException
                .With
                .Message
                .EqualTo("No such sender exists!"));
        }

        [Test]
        public void GetBySenderOrderedByAmountDescendingShouldReturnAllTransactionsWithTheGivenSender()
        {
            var otherTransaction = new Transaction(2, TransactionStatus.Successfull, "Svetlio", "Johnny", 5000);
            this.chainblock.Add(otherTransaction);
            var anotherTransaction = new Transaction(3, TransactionStatus.Successfull, "Svetlio", "Vankata", 6000);
            this.chainblock.Add(anotherTransaction);
            var abortedTransaction = new Transaction(4, TransactionStatus.Aborted, "Svetlio", "Vankata", 6000);
            this.chainblock.Add(abortedTransaction);
            var expectedCollection = new List<ITransaction>()
            {
                anotherTransaction,
                abortedTransaction,
                otherTransaction
            };

            var actualCollection = this.chainblock
                        .GetBySenderOrderedByAmountDescending("Svetlio");

            CollectionAssert.AreEqual(expectedCollection, actualCollection);
        }

        [Test]
        public void GetByReceiverOrderedByAmountThenByIdShouldThrowInvalidOperationExceptionWhenNoSuchReceiverFound()
        {
            Assert
                .That(
                () => this.chainblock.GetByReceiverOrderedByAmountThenById("Gosho"),
                Throws
                .InvalidOperationException
                .With
                .Message
                .EqualTo("No such receiver found!"));
        }

        [Test]
        public void GetByReceiverOrderedByAmountThenByIdShouldReturnAllTransactionsWithGivenReceiverOrderedByAmountDescendingThenByIdAscending()
        {
            var otherTransaction = new Transaction(2, TransactionStatus.Successfull, "Johnny", "Svetlio", 5000);
            this.chainblock.Add(otherTransaction);
            var anotherTransaction = new Transaction(3, TransactionStatus.Successfull, "Vankata", "Svetlio", 6000);
            this.chainblock.Add(anotherTransaction);
            var abortedTransaction = new Transaction(4, TransactionStatus.Aborted, "Vankata", "Svetlio", 6000);
            this.chainblock.Add(abortedTransaction);
            var expectedCollection = new List<ITransaction>()
            {
                anotherTransaction,
                abortedTransaction,
                otherTransaction,
            };

            var actualCollection = this.chainblock
                            .GetByReceiverOrderedByAmountThenById("Svetlio");

            CollectionAssert.AreEqual(expectedCollection, actualCollection);
        }

        [Test]
        public void GetByTransactionStatusAndMaximumAmountShouldReturnEmptyCollectionWhenNoSuchStatusFound()
        {
            var expectedCollection = new List<ITransaction>();

            var actualCollection = this.chainblock
                            .GetByTransactionStatusAndMaximumAmount(
                                    TransactionStatus.Unauthorized,
                                    200);

            Assert.AreEqual(expectedCollection, actualCollection);
        }

        [Test]
        public void GetByTransactionStatusAndMaximumAmountShouldReturnAllTransactionWithGivenStatusAndMaximumAllowedAmountOrderedByAmountDescending()
        {
            var otherTransaction = new Transaction(2, TransactionStatus.Successfull, "Johnny", "Svetlio", 5000);
            this.chainblock.Add(otherTransaction);
            var anotherTransaction = new Transaction(3, TransactionStatus.Successfull, "Vankata", "Svetlio", 6000);
            this.chainblock.Add(anotherTransaction);
            var abortedTransaction = new Transaction(4, TransactionStatus.Aborted, "Vankata", "Svetlio", 6000);
            this.chainblock.Add(abortedTransaction);

            var expectedCollection = new List<ITransaction>()
            {
                otherTransaction,
                this.transaction
            };

            var actualCollection = this.chainblock
                            .GetByTransactionStatusAndMaximumAmount(
                                    TransactionStatus.Successfull,
                                    5500);

            Assert.AreEqual(expectedCollection, actualCollection);
        }

        [Test]
        public void GetBySenderAndMinimumAmountDescendingShouldThrowInvalidOperationExceptionWhenNoSuchSenderFound()
        {
            Assert
                .That(
                () => this.chainblock.GetBySenderAndMinimumAmountDescending("Pesho", 200),
                Throws
                .InvalidOperationException
                .With
                .Message
                .EqualTo("No such sender found!"));
        }
        
        [Test]
        public void GetBySenderAndMinimumAmountDescendingShouldThrowInvalidOperationExceptionWhenNoSuchMinimumAmountFound()
        {
            Assert
                .That(
                () => this.chainblock.GetBySenderAndMinimumAmountDescending("Svetlio", 2000),
                Throws
                .InvalidOperationException
                .With
                .Message
                .EqualTo("No such sender found!"));
        }

        [Test]
        public void GetBySenderAndMinimumAmountDescendingShouldReturnAlltransactionsWithGivenSenderAndAmountBiggerThanGivenAmountOrderedByAmountDescending()
        {
            var otherTransaction = new Transaction(2, TransactionStatus.Successfull, "Svetlio", "Johnny", 5000);
            this.chainblock.Add(otherTransaction);
            var anotherTransaction = new Transaction(3, TransactionStatus.Successfull, "Svetlio", "Vankata", 6000);
            this.chainblock.Add(anotherTransaction);
            var abortedTransaction = new Transaction(4, TransactionStatus.Aborted, "Svetlio", "Vankata", 6000);
            this.chainblock.Add(abortedTransaction);

            var expectedCollection = new List<ITransaction>()
            {
                anotherTransaction,
                abortedTransaction,
                otherTransaction
            };

            var actualCollection = this.chainblock
                            .GetBySenderAndMinimumAmountDescending(
                                    "Svetlio",
                                    2000);

            Assert.AreEqual(expectedCollection, actualCollection);
        }

        [Test]
        public void GetByReceiverAndAmountRangeShouldThrowInvalidOperationExceptionWhenNoSuchReceiverFound()
        {
            Assert
                .That(
                () => this.chainblock.GetByReceiverAndAmountRange("Gosho", 10, 100),
                Throws
                .InvalidOperationException
                .With
                .Message
                .EqualTo("No such receiver found!"));
        }

        [Test]
        public void GetByReceiverAndAmountRangeShouldThrowInvalidOperationExceptionWhenNoSuchLowerBoundFound()
        {
            Assert
                .That(
                () => this.chainblock.GetByReceiverAndAmountRange("Pesho", 2000, 10000),
                Throws
                .InvalidOperationException
                .With
                .Message
                .EqualTo("No such transaction with this lower bound found!"));
        }

        [Test]
        public void GetByReceiverAndAmountRangeShouldThrowInvalidOperationExceptionWhenNoSuchUpperBoundFound()
        {
            Assert
                .That(
                () => this.chainblock.GetByReceiverAndAmountRange("Pesho", 10, 100),
                Throws
                .InvalidOperationException
                .With
                .Message
                .EqualTo("No such transaction with this upper bound found!"));
        }

        [Test]
        public void GetByReceiverAndAmountRangeShouldReturnAllTransactionsWithGivenReceiverAndAmountWithinRangeOrderedByAmountDescendingThenById()
        {
            var otherTransaction = new Transaction(2, TransactionStatus.Successfull, "Johnny", "Svetlio", 5000);
            this.chainblock.Add(otherTransaction);
            var anotherTransaction = new Transaction(3, TransactionStatus.Successfull, "Vankata", "Svetlio", 6000);
            this.chainblock.Add(anotherTransaction);
            var abortedTransaction = new Transaction(4, TransactionStatus.Aborted, "Vankata", "Svetlio", 6000);
            this.chainblock.Add(abortedTransaction);

            var expectedCollection = new List<ITransaction>()
            {
                anotherTransaction,
                abortedTransaction,
                otherTransaction
            };

            var actualCollection = this.chainblock
                            .GetByReceiverAndAmountRange(
                                    "Svetlio",
                                    2000,
                                    6500);

            Assert.AreEqual(expectedCollection, actualCollection);
        }

        [Test]
        public void GetAllInAmountRangeShouldReturnEmptyCollectionWhenNoTransactionFoundWithinTheGivenRange()
        {
            var expectedCollection = new List<ITransaction>();

            var actualCollection = this.chainblock.GetAllInAmountRange(10, 1000);

            Assert.AreEqual(expectedCollection, actualCollection);
        }

        [Test]
        public void GetAllInAmountRangeShouldReturnAllTransactionsFoundWithinTheGivenRange()
        {
            var otherTransaction = new Transaction(2, TransactionStatus.Successfull, "Johnny", "Svetlio", 5000);
            this.chainblock.Add(otherTransaction);
            var anotherTransaction = new Transaction(3, TransactionStatus.Successfull, "Vankata", "Svetlio", 6000);
            this.chainblock.Add(anotherTransaction);
            var abortedTransaction = new Transaction(4, TransactionStatus.Aborted, "Vankata", "Svetlio", 6000);
            this.chainblock.Add(abortedTransaction);

            var expectedCollection = new List<ITransaction>()
            {
                this.transaction,
                otherTransaction,
                anotherTransaction,
                abortedTransaction
            };

            var actualCollection = this.chainblock
                            .GetAllInAmountRange(
                                    1500,
                                    6000);

            Assert.AreEqual(expectedCollection, actualCollection);
        }
    }
}
