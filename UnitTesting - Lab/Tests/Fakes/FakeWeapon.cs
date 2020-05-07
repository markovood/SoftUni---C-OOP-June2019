using System;

using Skeleton.Contracts;

namespace Tests.Fakes
{
    public class FakeWeapon : IWeapon
    {
        public int AttackPoints => throw new NotImplementedException();

        public int DurabilityPoints => throw new NotImplementedException();

        public void Attack(ITarget target)
        {
            
        }
    }
}
