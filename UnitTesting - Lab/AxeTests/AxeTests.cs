using NUnit.Framework;

namespace AxeTests
{
    [TestFixture]
    public class AxeTests
    {
        private const int ATTACK_ENABLED = 10;
        private const int ATTACK_DISABLED = 0;
        private const int DURABILITY_ENABLED = 10;
        private const int DURABILITY_DISABLED = 0;

        private Axe axe;
        private Dummy target;

        [SetUp]
        public void CreateDummyTarget()
        {
            const int health = 100;
            const int xp = 50;

            this.target = new Dummy(health, xp);
        }

        [Test]
        public void AxeLoosesDurabilityAfterAttack()
        {
            this.axe = new Axe(ATTACK_ENABLED, DURABILITY_ENABLED);

            int initialDurability = axe.DurabilityPoints;

            axe.Attack(this.target);
            int actualDurability = axe.DurabilityPoints;

            Assert.That(actualDurability, Is.LessThan(initialDurability), "Axe is not loosing durability points.");
        }

        [Test]
        public void AttackingWithBrokenAxeShouldThrowInvalidOperationException()
        {
            this.axe = new Axe(ATTACK_ENABLED, DURABILITY_DISABLED);

            // Assert.Throws<InvalidOperationException>(() => this.axe.Attack(this.target));
            Assert.That(() => this.axe.Attack(this.target),
                Throws.
                InvalidOperationException.
                With.
                Message.
                EqualTo("Axe is broken."), "Make sure you cannot attack with broken axe");
        }
    }
}
