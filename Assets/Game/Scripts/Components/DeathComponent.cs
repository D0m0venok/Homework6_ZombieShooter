using Atomic;

namespace ZombieShooter
{
    public sealed class DeathComponent : IDeathComponent
    {
        public IAtomicEvent<Entity> DeathEvent { get; }
        
        public DeathComponent(IAtomicEvent<Entity> deathEvent)
        {
            DeathEvent = deathEvent;
        }
    }
}