using Atomic;

namespace ZombieShooter
{
    public sealed class ZombieAttackAgent
    {
        private readonly Entity _zombie;
        private readonly IAtomicValue<bool> _isReached;

        public ZombieAttackAgent(Entity zombie, IAtomicValue<bool> isReached)
        {
            _zombie = zombie;
            _isReached = isReached;
        }
        public void Update()
        {
            if (!_isReached.Value)
                return;

            if (!_zombie.TryGetEntityComponent(out IAttackComponent attackComponent))
                return;

            attackComponent.Attack();
        }
    }
}