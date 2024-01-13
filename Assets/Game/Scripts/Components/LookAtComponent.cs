using Atomic;
using UnityEngine;

namespace ZombieShooter
{
    public sealed class LookAtComponent : ILookAtComponent
    {
        private readonly IAtomicVariable<Vector3> _point;

        public LookAtComponent(IAtomicVariable<Vector3> point)
        {
            _point = point;
        }

        public void LookAt(Vector3 point)
        {
            _point.Value = point;
        }
    }
}