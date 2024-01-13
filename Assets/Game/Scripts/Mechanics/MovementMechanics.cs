using Atomic;
using UnityEngine;

namespace ZombieShooter
{
    public sealed class MovementMechanics
    {
        private readonly IAtomicValue<bool> _enabled;
        private readonly IAtomicValue<Vector3> _moveDirection;
        private readonly IAtomicValue<float> _moveSpeed;
        private readonly Transform _transform;

        public MovementMechanics(IAtomicValue<bool> enabled, IAtomicValue<Vector3> moveDirection,
            IAtomicValue<float> moveSpeed, Transform transform)
        {
            _enabled = enabled;
            _moveDirection = moveDirection;
            _moveSpeed = moveSpeed;
            _transform = transform;
        }

        public void Update()
        {
            if (_enabled.Value)
            {
                var moveOffset = _moveDirection.Value * (_moveSpeed.Value * Time.deltaTime);
                _transform.position += moveOffset;
            }
        }
    }
}