using System;
using Atomic;
using Sirenix.OdinInspector;

namespace ZombieShooter
{
    [Serializable]
    public sealed class FireEvent : IAtomicEvent
    {
        private IAtomicEvent _spawnBulletAction;
        private IAtomicVariable<int> _charges;
        
        public void Init(IAtomicEvent spawnBulletAction, IAtomicVariable<int> charges)
        {
            _spawnBulletAction = spawnBulletAction;
            _charges = charges;
        }
        
        [Button]
        public void Invoke()
        {
            _charges.Value--;
            _spawnBulletAction.Invoke();
        }
        public void Subscribe(Action action)
        {
            _spawnBulletAction.Subscribe(action);
        }
        public void Unsubscribe(Action action)
        {
            _spawnBulletAction.Unsubscribe(action);
        }
    }
}