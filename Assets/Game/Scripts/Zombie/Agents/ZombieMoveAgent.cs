using Atomic;
using UnityEngine;

namespace ZombieShooter
{
    public sealed class ZombieMoveAgent
    {
        private readonly Entity _zombie;
        private readonly Transform _target;
        private readonly float _positionInaccuracy;

        public AtomicVariable<bool> IsReached { get; } = new (false);

        public ZombieMoveAgent(Entity zombie, Transform target, float positionInaccuracy)
        {
            _zombie = zombie;
            _positionInaccuracy = positionInaccuracy;
            _target = target;
        }

        public void Update()
        {
            if (_zombie.TryGetEntityComponent(out ILookAtComponent lookAtComponent))
                lookAtComponent.LookAt(_target.transform.position);

            var vector = _target.transform.position - _zombie.transform.position;
            IsReached.Value = vector.magnitude <= _positionInaccuracy;
            
            if (IsReached)
                vector = Vector3.zero;
            
            if (_zombie.TryGetEntityComponent(out IMoveComponent moveComponent))
                moveComponent.Move(vector.normalized);
        }
    }
}