using Atomic;

namespace ZombieShooter
{
    public sealed class FireAnimationComponent : IFireAnimationComponent
    {
        private readonly IAtomicAction _fireEvent;
        
        public FireAnimationComponent(IAtomicAction fireEvent)
        {
            _fireEvent = fireEvent;
        }

        public void Fire()
        {
            _fireEvent.Invoke();
        }
    }
}