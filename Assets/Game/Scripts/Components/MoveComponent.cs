using Atomic;
using UnityEngine;

namespace ZombieShooter
{
    public sealed class MoveComponent : IMoveComponent
    {
        private readonly IAtomicVariable<Vector3> _moveDirection;
        private readonly IAtomicVariable<bool> _enable;

        public MoveComponent(IAtomicVariable<Vector3> moveDirection, IAtomicVariable<bool> enable)
        {
            _moveDirection = moveDirection;
            _enable = enable;
        }

        public void Move(Vector3 moveDirection)
        {
            _moveDirection.Value = moveDirection;
        }
        public void EnableMove()
        {
            _enable.Value = true;
        }
        public void DisableMove()
        {
            _enable.Value = false;
        }
    }
}