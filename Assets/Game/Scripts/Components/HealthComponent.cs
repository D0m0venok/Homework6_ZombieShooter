using Atomic;

namespace ZombieShooter
{
    public sealed class HealthComponent : IHealthComponent
    {
        private readonly IAtomicEvent<int> _hitEvent;

        public IAtomicVariable<int> HitPoints { get; }
        public IAtomicValue<bool> IsAlive { get; }

        public HealthComponent(IAtomicVariable<int> hitPoints, IAtomicEvent<int> hitEvent, IAtomicValue<bool> isAlive)
        {
            HitPoints = hitPoints;
            _hitEvent = hitEvent;
            IsAlive = isAlive;
        }

        public void DealDamage(int damage)
        {
            if(IsAlive.Value)
                _hitEvent.Invoke(damage);
        }
    }
}