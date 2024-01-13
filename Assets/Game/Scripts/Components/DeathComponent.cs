using Atomic;

namespace ZombieShooter
{
    public sealed class DeathComponent : IDeathComponent
    {
        public IAtomicEvent<IEntity> DeathEvent { get; }
        
        public DeathComponent(IAtomicEvent<IEntity> deathEvent)
        {
            DeathEvent = deathEvent;
        }
    }
}