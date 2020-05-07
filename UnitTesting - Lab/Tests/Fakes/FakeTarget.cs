using System;

using Skeleton.Contracts;

namespace Tests.Fakes
{
    public class FakeTarget : ITarget
    {
        public int Health => throw new NotImplementedException();

        public int GiveExperience()
        {
            return 10;
        }

        public bool IsDead()
        {
            return true;
        }

        public void TakeAttack(int attackPoints)
        {
            throw new NotImplementedException();
        }
    }
}
