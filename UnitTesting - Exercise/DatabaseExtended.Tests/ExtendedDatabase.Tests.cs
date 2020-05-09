using System;

using ExtendedDatabase;
using NUnit.Framework;

namespace Tests
{
    public class ExtendedDatabaseTests
    {
        private Person[] persons;
        private ExtendedDatabase.ExtendedDatabase db;

        [SetUp]
        public void Setup()
        {
            this.persons = new Person[] 
            {
                new Person(1L, "Pesho"),
                new Person(2L, "Gosho"),
                new Person(3L, "Stamat")
            };

            this.db = new ExtendedDatabase.ExtendedDatabase(this.persons);
        }

        [Test]
        public void ConstructorShouldCreateDatabaseWithCorrectNumberOfPersons()
        {
            int expectedCount = this.persons.Length;
            int actualCount = this.db.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void AddShouldThrowInvalidOperationExceptionWhenPersonWithSameNameExists()
        {
            var existingPerson = new Person(4L, "Gosho");

            Assert
                .That(
                () => this.db.Add(existingPerson),
                Throws
                .InvalidOperationException
                .With
                .Message
                .EqualTo("There is already user with this username!"));
        }

        [Test]
        public void AddShouldThrowInvalidOperationExceptionWhenPersonWithSameIdExists()
        {
            var existingPerson = new Person(2L, "Gancho");

            Assert
                .That(
                () => this.db.Add(existingPerson),
                Throws
                .InvalidOperationException
                .With
                .Message
                .EqualTo("There is already user with this Id!"));
        }

        [Test]
        public void AddShouldThrowInvalidOperationExceptionWhenAddingMoreThan16()
        {
            for (long i = 4; i <= 16; i++)
            {
                var person = new Person(i, $"SomeName{i}");
                this.db.Add(person);
            }

            var person17 = new Person(17L, "Martin");

            Assert
                .That(
                () => this.db.Add(person17),
                Throws
                .InvalidOperationException
                .With
                .Message
                .EqualTo("Array's capacity must be exactly 16 integers!"));
        }

        [Test]
        public void RemoveShouldThrowInvalidOperationExceptionWhenRemovingFromEmptyDB()
        {
            this.db = new ExtendedDatabase.ExtendedDatabase();

            Assert.Throws<InvalidOperationException>(() => this.db.Remove());
        }

        [Test]
        public void RemoveShouldDecreaseCountByOne()
        {
            int expectedCount = 2;

            this.db.Remove();
            int actualCount = this.db.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void FindByUsernameShouldThrowArgumentNullExceptionWhenUsernameIsNullOrEmpty()
        {
            string nullUsername = null;

            Assert
                .That(
                () => this.db.FindByUsername(nullUsername),
                Throws
                .ArgumentNullException
                .With
                .Message
                .Contains("Username parameter is null!"));
        }

        [Test]
        public void FindByUsernameShouldThrowInvalidOperationExceptionWhenUsernameIsNotPresent()
        {
            string username = "Gancho";

            Assert
                .That(
                () => this.db.FindByUsername(username),
                Throws
                .InvalidOperationException
                .With
                .Message
                .EqualTo("No user is present by this username!"));
        }

        [Test]
        public void FindByUsernameMustBeCaseSensitive()
        {
            string existingUser = "gosho";

            Assert
                .That(
                () => this.db.FindByUsername(existingUser),
                Throws
                .InvalidOperationException
                .With
                .Message
                .EqualTo("No user is present by this username!"));
        }

        [Test]
        public void FindByUsernameReturnsCorrectPerson()
        {
            string expectedUsername = "Gosho";

            Person gosho = this.db.FindByUsername(expectedUsername);
            string actualUsername = gosho.UserName;

            Assert.AreEqual(expectedUsername, actualUsername);
        }

        [Test]
        public void FindByIdShouldThrowInvalidOperationExceptionWhenIdIsNotPresent()
        {
            long id = 9L;

            Assert
                .That(
                () => this.db.FindById(id),
                Throws
                .InvalidOperationException
                .With
                .Message
                .EqualTo("No user is present by this ID!"));
        }

        [Test]
        public void FindByIdShouldThrowArgumentOutOfRangeExceptionWhenNegativeId()
        {
            long negativeId = -2L;

            Assert
                .That(
                () => this.db.FindById(negativeId),
                Throws
                .Exception
                .With
                .Message
                .Contains("Id should be a positive number!"));
        }

        [Test]
        public void FindByIdShouldReturnCorrectPerson()
        {
            long expectedId = 2L;

            Person gosho = this.db.FindById(expectedId);
            long actualId = gosho.Id;

            Assert.AreEqual(expectedId, actualId);
        }
    }
}