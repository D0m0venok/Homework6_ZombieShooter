namespace ZombieShooter
{
    public class ZombieAnimatorDispatcher : AnimatorDispatcher
    {
        public void MeleeAttack()
        {
            if(_entity.TryGetEntityComponent(out IMeleeAttackAnimationComponent meleeAttackComponent))
                meleeAttackComponent.MeleeAttack();
        }

    }
}