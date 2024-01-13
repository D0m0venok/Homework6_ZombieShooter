using System;
using Atomic;
using UnityEngine;

namespace ZombieShooter
{
    [Serializable]
    public sealed class LookAtSection
    {
        public AtomicVariable<bool> Enable = new(true);
        public AtomicVariable<Vector3> LookAtPoint;
        
        private LookAtMechanics _lookAtMechanics;
        
        public void Init(Transform transform)
        {
            _lookAtMechanics = new LookAtMechanics(LookAtPoint, Enable, transform);
        }
        
        public void Update()
        {
            _lookAtMechanics.Update();
        }
    }
}