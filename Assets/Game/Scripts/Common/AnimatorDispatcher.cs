using UnityEngine;

namespace ZombieShooter
{
    public class AnimatorDispatcher : MonoBehaviour
    {
        [SerializeField] protected Entity _entity;
        
        public void EnableMove()
        {
            if(_entity.TryGetEntityComponent(out IMoveComponent moveComponent))
                moveComponent.EnableMove();
        }
        public void DisableMove()
        {
            if(_entity.TryGetEntityComponent(out IMoveComponent moveComponent))
                moveComponent.DisableMove();
        }
    }
}