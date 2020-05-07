using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class DummyTests
    {
        private const int HEALTH_ENABLED = 100;
        private const int HEALTH_DISABLED = 0;
        private const int XP_ENABLED = 10;
        private const int XP_DISABLED = 0;
        private const int ATTACK_POINTS_TO_TAKE = 10;

        private Dummy target;

        [Test]
        public void DummyLosesHealthIfAttacked()
        {
            this.target = new Dummy(HEALTH_ENABLED, XP_ENABLED);
            var initialHealth = this.target.Health;

            this.target.TakeAttack(ATTACK_POINTS_TO_TAKE);
            int actualHealth = this.target.Health;

            Assert.That(actualHealth, Is.LessThan(initialHealth));
        }

        [Test]
        public void DeadDummyThrowsExceptionIfAttacked()
        {
            this.target = new Dummy(HEALTH_DISABLED, XP_DISABLED);

            Assert
                .That(
                () => this.target.TakeAttack(ATTACK_POINTS_TO_TAKE),
                Throws
                .InvalidOperationException
                .With
                .Message.EqualTo("Dummy is dead."));
        }

        [Test]
        public void DeadDummyCanGiveXP()
        {
            this.target = new Dummy(HEALTH_DISABLED, XP_ENABLED);

            int xp = this.target.GiveExperience();

            Assert.That(xp, Is.EqualTo(XP_ENABLED));
        }

        [Test]
        public void AliveDummyCantGiveXP()
        {
            this.target = new Dummy(HEALTH_ENABLED, XP_ENABLED);

            Assert
                .That(() => this.target.GiveExperience(),
                Throws
                .InvalidOperationException
                .With
                .Message
                .EqualTo("Target is not dead."));
        }
    }
}
