using Atomic;

namespace ZombieShooter
{
    public sealed class DeathMechanics
    {
        private readonly IAtomicVariable<bool> _isAlive;
        private readonly IAtomicEvent<Entity> _death;

        public DeathMechanics(IAtomicVariable<bool> isAlive, IAtomicEvent<Entity> death)
        {
            _isAlive = isAlive;
            _death = death;
        }

        public void OnEnable()
        {
            _death.Subscribe(OnDeath);
        }

        public void OnDisable()
        {
            _death.Unsubscribe(OnDeath);
        }

        private void OnDeath(Entity entity)
        {
            if (!_isAlive.Value)
                return;    

            _isAlive.Value = false;
        }
    }
}