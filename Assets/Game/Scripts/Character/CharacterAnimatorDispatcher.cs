namespace ZombieShooter
{
    public class CharacterAnimatorDispatcher : AnimatorDispatcher
    {
        public void Fire()
        {
            if(_entity.TryGetEntityComponent(out IFireAnimationComponent fireComponent))
                fireComponent.Fire();
        }
    }
}