using System;
using Atomic;
using Sirenix.OdinInspector;

namespace ZombieShooter
{
    [Serializable]
    public sealed class AttackEvent : IAtomicEvent
    {
        private event Action _event;
        private IAtomicFunction<bool> _attackCondition;

        public void Init(IAtomicFunction<bool> attackCondition)
        {
            _attackCondition = attackCondition;
        }
        [Button]
        public void Invoke()
        {
            if(!_attackCondition.Invoke())
                return;
            
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