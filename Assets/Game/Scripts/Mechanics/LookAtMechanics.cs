using Atomic;
using UnityEngine;

namespace ZombieShooter
{
    public sealed class LookAtMechanics
    {
        private readonly IAtomicValue<Vector3> _point;
        private readonly IAtomicValue<bool> _enabled;
        private readonly Transform _target;
        
        public LookAtMechanics(IAtomicValue<Vector3> point, IAtomicValue<bool> enabled, Transform target)
        {
            _point = point;
            _enabled = enabled;
            _target = target;
        }

        public void Update()
        {
            if(!_enabled.Value)
                return;
            
            _target.LookAt(_point.Value, Vector3.up);
        }
    }
}