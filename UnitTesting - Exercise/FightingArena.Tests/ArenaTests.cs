using System.Linq;

using FightingArena;
using NUnit.Framework;

namespace Tests
{
    public class ArenaTests
    {
        private Arena arena;
        private Warrior someWarrior;

        [SetUp]
        public void Setup()
        {
            this.arena = new Arena();
            this.someWarrior = new Warrior("Pesho", 50, 100);
        }

        [Test]
        public void ConstructorShouldInitializeInternalCollection()
        {
            Assert.IsNotNull(arena.Warriors);
        }

        [Test]
        public void CountShouldReturnCorrectWarriorsCount()
        {
            int expectedCount = 0;

            int actualCount = this.arena.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void EnrollShouldThrowInvalidOperationExceptionWhenWarriorWithSameNameAlreadyExists()
        {
            this.arena.Enroll(this.someWarrior);

            Assert
                .That(
                () => this.arena.Enroll(this.someWarrior),
                Throws
                .InvalidOperationException
                .With
                .Message
                .EqualTo("Warrior is already enrolled for the fights!"));
        }

        [Test]
        public void EnrollShouldAddWarriorToWarriorsCollection()
        {
            this.arena.Enroll(this.someWarrior);
            Warrior expectedWarrior = this.someWarrior;

            Warrior actualWarrior = this.arena.Warriors.First();

            Assert.AreSame(expectedWarrior, actualWarrior);
        }

        [Test]
        public void FightShouldThrowInvalidOperationExceptionWhenAttackerDoesntExistInWarriorsCollection()
        {
            var deffender = this.someWarrior;
            this.arena.Enroll(deffender);

            Assert
                .That(
                () => this.arena.Fight("Stoiko", "Gunio"),
                Throws
                .InvalidOperationException
                .With
                .Message
                .Contains("There is no fighter with name "));
        }

        [Test]
        public void FightShouldThrowInvalidOperationExceptionWhenDeffenderDoesntExistInWarriorsCollection()
        {
            var attacker = this.someWarrior;
            this.arena.Enroll(attacker);

            Assert
                .That(
                () => this.arena.Fight("Stoiko", "Gunio"),
                Throws
                .InvalidOperationException
                .With
                .Message
                .Contains("There is no fighter with name "));
        }

        [Test]
        public void FightShouldDecreaseAttackerHp()
        {
            var attacker = this.someWarrior;
            this.arena.Enroll(attacker); 
            var deffender = new Warrior("Gunio", 40, 80);
            this.arena.Enroll(deffender);
            int expectedAttackerHp = attacker.HP - deffender.Damage;

            this.arena.Fight("Pesho", "Gunio");
            int actualAttackerHp = attacker.HP;

            Assert.AreEqual(expectedAttackerHp, actualAttackerHp);
        }
    }
}
