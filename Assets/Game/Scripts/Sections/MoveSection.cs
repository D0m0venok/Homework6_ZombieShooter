using System;
using Atomic;
using UnityEngine;

namespace ZombieShooter
{
    [Serializable]
    public sealed class MoveSection
    {
        public AtomicVariable<bool> Enable = new(true);
        public AtomicVariable<Vector3> MoveDirection;
        public AtomicValue<float> Speed = new(5);
        public AtomicFunction<bool> IsMoving;
        
        private MovementMechanics _movementMechanics;

        public void Init(Transform transform)
        {
            _movementMechanics = new MovementMechanics(Enable, MoveDirection, Speed, transform);
            IsMoving = new AtomicFunction<bool>(() => MoveDirection.Value.sqrMagnitude > 0 && Enable.Value);
        }
        public void OnEnable()
        {
            Enable.Subscribe(OnMoveEnableChanged);
        }
        public void OnDisable()
        {
            Enable.Unsubscribe(OnMoveEnableChanged);
        }
        public void Update()
        {
            _movementMechanics.Update();
        }

        private void OnMoveEnableChanged(bool isEnable)
        {
            if(!isEnable)
                MoveDirection.Value = Vector3.zero;
        }
    }
}