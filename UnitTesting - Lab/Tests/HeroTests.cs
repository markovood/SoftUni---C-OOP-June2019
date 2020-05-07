using Moq;
using NUnit.Framework;
using Skeleton.Contracts;
using Tests.Fakes;

namespace Tests
{
    [TestFixture]
    public class HeroTests
    {
        [Test]
        public void AttackShouldGainXPWhenTargetIsDead()
        {
            var weapon = new Mock<IWeapon>();
            //var weaponFake = new FakeWeapon();

            var target = new Mock<ITarget>();
            target.Setup(m => m.IsDead()).Returns(true);
            target.Setup(m => m.GiveExperience()).Returns(10);
            //var targetFake = new FakeTarget();

            Hero hero = new Hero("Pesho", weapon.Object);//weaponFake);
            int initialXP = hero.Experience;

            hero.Attack(target.Object);//targetFake);
            int actualXP = hero.Experience;

            Assert.That(actualXP, Is.GreaterThan(initialXP), "Hero is not gaining XP points.");
        }
    }
}
