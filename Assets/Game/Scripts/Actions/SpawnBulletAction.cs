using System;
using Atomic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace ZombieShooter
{
    [Serializable]
    public sealed class SpawnBulletAction : IAtomicEvent
    {
        private BulletSystem _bulletSystem;
        private Transform _firePoint;
        private event Action _event;

        public void Init(BulletSystem bulletSystem, Transform firePoint)
        {
            _bulletSystem = bulletSystem;
            _firePoint = firePoint;
        }
        
        [Button]
        public void Invoke()
        {
            _bulletSystem.FlyBullet(_firePoint.position, _firePoint.forward);
            _event?.Invoke();
        }
        public void Subscribe(Action action)
        {
            _event += action;
        }
        public void Unsubscribe(Action action)
        {
            _event -= action;
        }
    }
}