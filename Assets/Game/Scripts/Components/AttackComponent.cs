using Atomic;

namespace ZombieShooter
{
    public sealed class AttackComponent : IAttackComponent
    {
        private readonly IAtomicAction _attackRequest;
        
        public AttackComponent(IAtomicAction attackRequest)
        {
            _attackRequest = attackRequest;
        }

        public void Attack()
        {
            _attackRequest.Invoke();
        }
    }
}