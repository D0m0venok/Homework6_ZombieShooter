using Atomic;

namespace ZombieShooter
{
    public sealed class MeleeAttackAnimationComponent : IMeleeAttackAnimationComponent
    {
        private readonly IAtomicAction _meleeAttackEvent; 
        
        public MeleeAttackAnimationComponent(IAtomicAction meleeAttackEvent)
        {
            _meleeAttackEvent = meleeAttackEvent;
        }
        
        public void MeleeAttack()
        {
            _meleeAttackEvent.Invoke();
        }
    }
}