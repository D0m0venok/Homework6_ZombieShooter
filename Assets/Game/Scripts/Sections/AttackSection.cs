using System;
using Atomic;
using Extensions;

namespace ZombieShooter
{
    [Serializable]
    public sealed class AttackSection
    {
        public AtomicVariable<bool> Enable = new(true);
        public AttackEvent AttackEvent;
        public AtomicFunction<bool> AttackCondition;
        public AtomicValue<float> Cooldown = new(1);
        
        private Countdown _countdown;

        public void Init(Func<bool> addAttackCondition = null)
        {
            _countdown = new Countdown(Cooldown.Value);
            AttackCondition = new AtomicFunction<bool>(() => Enable.Value && _countdown.IsEnded && 
                                          (addAttackCondition == null || addAttackCondition.Invoke()));
            AttackEvent.Init(AttackCondition);
        }

        public void Update()
        {
            if(!Enable.Value)
                return;
            
            _countdown.Update();
        }
        public void OnEnable()
        {
            AttackEvent.Subscribe(OnAttacked);
        }
        public void OnDisable()
        {
            AttackEvent.Unsubscribe(OnAttacked);
        }

        private void OnAttacked()
        {
            _countdown.Reset();
        }
    }
}