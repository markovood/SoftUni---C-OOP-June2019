using FightingArena;

using NUnit.Framework;

namespace Tests
{
    public class WarriorTests
    {
        private string name;
        private int damage;
        private int hp;
        private Warrior warrior;

        [SetUp]
        public void Setup()
        {
            this.name = "Pesho";
            this.damage = 10;
            this.hp = 10;
            this.warrior = new Warrior(this.name, this.damage, this.hp);
        }

        [Test]
        public void ConstructorShouldSetPropertyNameCorectly()
        {
            string expectedName = this.name;

            Assert.AreEqual(expectedName, this.warrior.Name);
        }

        [Test]
        public void ConstructorShouldSetPropertyDamageCorectly()
        {
            int expectedDamage = this.damage;

            Assert.AreEqual(expectedDamage, this.warrior.Damage);
        }

        [Test]
        public void ConstructorShouldSetPropertyHPCorectly()
        {
            int expectedHP = this.hp;

            Assert.AreEqual(expectedHP, this.warrior.HP);
        }

        [Test]
        public void NameShouldReturnCorrectName()
        {
            string expectedName = this.name;

            string actualName = this.warrior.Name;

            Assert.AreEqual(expectedName, actualName);
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void NameShouldThrowArgumentExceptionWhenSettingWithNullEmptyStringOrWhiteSpace(string name) 
        {
            Assert
                .That(
                () => new Warrior(name, this.damage, this.hp),
                Throws
                .ArgumentException
                .With
                .Message
                .EqualTo("Name should not be empty or whitespace!"));
        }

        [Test]
        public void DamageShouldReturnCorectDamage()
        {
            int expectedDamage = this.damage;

            int actualDamage = this.warrior.Damage;

            Assert.AreEqual(expectedDamage, actualDamage);
        }

        [TestCase(0)]
        [TestCase(-5)]
        public void DamageShouldThrowArgumentExceptionWhenSetWithZeroOrNegative(int damage)
        {
            Assert
                .That(
                () => new Warrior(this.name, damage, this.hp),
                Throws
                .ArgumentException
                .With
                .Message
                .EqualTo("Damage value should be positive!"));
        }

        [Test]
        public void HPShouldReturnCorectHP()
        {
            int expectedHP = this.hp;

            int actualHP = this.warrior.HP;

            Assert.AreEqual(expectedHP, actualHP);
        }

        [Test]
        public void HPShouldThrowArgumentExceptionWhenSettingNegativeValue()
        {
            int negativeHP = -5;

            Assert
                .That(
                () => new Warrior(this.name, this.damage, negativeHP),
                Throws
                .ArgumentException
                .With
                .Message
                .EqualTo("HP should not be negative!"));
        }

        [Test]
        public void AttackShouldThrowInvalidOperationExceptionWhenHPIsLessThanTheMinimum()
        {
            var warriorToAttack = new Warrior("Gosho", 15, 50);

            Assert
                .That(
                () => this.warrior.Attack(warriorToAttack),
                Throws
                .InvalidOperationException
                .With
                .Message
                .EqualTo("Your HP is too low in order to attack other warriors!"));
        }

        [Test]
        public void AttackShouldThrowInvalidOperationExceptionWhenWarriorUnderAttackHasHPLessThanTheMinimum()
        {
            this.warrior = new Warrior("Pesho", 10, 100);
            var warriorToAttack = new Warrior("Gosho", 15, 15);

            Assert
                .That(
                () => this.warrior.Attack(warriorToAttack),
                Throws
                .InvalidOperationException
                .With
                .Message
                .StartsWith("Enemy HP must be greater than "));
        }

        [Test]
        public void AttackShouldThrowInvalidOperationExceptionWhenHPIsLessThanWarriorUnderAttackDamage()
        {
            this.warrior = new Warrior("Pesho", 10, 50);
            var warriorToAttack = new Warrior("Gosho", 100, 50);

            Assert
                .That(
                () => this.warrior.Attack(warriorToAttack),
                Throws
                .InvalidOperationException
                .With
                .Message
                .EqualTo("You are trying to attack too strong enemy"));
        }

        [Test]
        public void AttackShouldDecreaseHPWithWarriorUnderAttackDamage()
        {
            this.warrior = new Warrior("Pesho", 100, 100);
            var warriorToAttack = new Warrior("Gosho", 50, 50);
            int expectedHP = this.warrior.HP - warriorToAttack.Damage;

            this.warrior.Attack(warriorToAttack);
            int actualHP = this.warrior.HP;

            Assert.AreEqual(expectedHP, actualHP);
        }

        [Test]
        public void AttackShouldSetWarriorUnderAttackHpToZeroWhenDamageIsGreaterThanWarriorUnderAttackHp()
        {
            this.warrior = new Warrior("Pesho", 100, 100);
            var warriorToAttack = new Warrior("Gosho", 50, 50);
            int expectedHP = 0;

            this.warrior.Attack(warriorToAttack);
            int actualHP = warriorToAttack.HP;

            Assert.AreEqual(expectedHP, actualHP);
        }

        [Test]
        public void AttackShouldDecreaseWarriorUnderAttackHpWithDamageWhenDamageIsLessThanWarriorUnderAttackHp()
        {
            this.warrior = new Warrior("Pesho", 50, 100);
            var warriorToAttack = new Warrior("Gosho", 50, 100);
            int expectedHP = warriorToAttack.HP - this.warrior.Damage;

            this.warrior.Attack(warriorToAttack);
            int actualHP = warriorToAttack.HP;

            Assert.AreEqual(expectedHP, actualHP);
        }
    }
}