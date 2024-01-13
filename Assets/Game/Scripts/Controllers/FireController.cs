using Atomic;

namespace ZombieShooter
{
    public sealed class FireController : IGameStartListener, IGameFinishListener
    {
        private readonly IEntity _entity;
        private readonly IFireInput _fireInput;
        
        public FireController(IEntity entity, IFireInput fireInput)
        {
            _entity = entity;
            _fireInput = fireInput;
        }

        public void OnStart()
        {
            _fireInput.OnFired += Fire;
        }
        public void OnFinish()
        {
            _fireInput.OnFired -= Fire;
        }

        private void Fire()
        {
            if (_entity.TryGetEntityComponent(out IAttackComponent fireComponent))
                fireComponent.Attack();
        }
    }
}