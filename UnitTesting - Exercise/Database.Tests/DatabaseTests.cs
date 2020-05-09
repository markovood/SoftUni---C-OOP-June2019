using System.Linq;

using NUnit.Framework;

namespace Tests
{
    public class DatabaseTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void StoringArrayCapacityMustBeExactly16Integers()
        {
            var database = new Database.Database(Enumerable.Range(1, 16).ToArray());
            int expectedCapacity = 16;

            int actualCapacity = database.Count;

            Assert.That(actualCapacity, Is.EqualTo(expectedCapacity));
        }

        [Test]
        public void ShouldThrowInvalidOperationExceptionWhenStoringArrayCapacityExceeds16()
        {
            Assert
                .That(() => new Database.Database(Enumerable.Range(1, 20).ToArray()), 
                Throws
                .InvalidOperationException
                .With
                .Message
                .EqualTo("Array's capacity must be exactly 16 integers!"));
        }

        [Test]
        public void AddShouldAddElementAtNextFreeCell()
        {
            var database = new Database.Database(1, 2, 3);
            int initialCount = database.Count;
            int integerToAdd = 4;

            database.Add(integerToAdd);
            int actual = database.Count;

            Assert.That(actual, Is.EqualTo(initialCount + 1));
        }

        [Test]
        public void RemoveShouldDeleteOnlyElementAtLastIndex()
        {
            var database = new Database.Database(1, 2, 3);
            int countBeforeRemove = database.Count;

            database.Remove();
            int countAfter = database.Count;

            Assert.That(countAfter, Is.EqualTo(countBeforeRemove - 1));
        }

        [Test]
        public void ShouldThrowInvalidOperationExceptionWhenRemovingFromEmptyDatabase()
        {
            var database = new Database.Database();

            Assert
                .That(
                () => database.Remove(),
                Throws
                .InvalidOperationException
                .With
                .Message
                .EqualTo("The collection is empty!"));
        }

        [Test]
        public void FetchShouldReturnElementsInDatabaseAsArray()
        {
            int[] expectedElements = new int[] { 1, 2, 3 };
            var database = new Database.Database(expectedElements);

            int[] actualElements = database.Fetch();

            Assert.AreEqual(expectedElements, actualElements);
        }

        [Test]
        public void ConstructorShouldCreateDatabaseWithCorrectNumberOfElements()
        {
            var expectedElements = new int[] { 1, 2, 3 };
            var database = new Database.Database(expectedElements);

            Assert.AreEqual(expectedElements.Length, database.Count);
        }
    }
}