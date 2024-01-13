using System;
using Atomic;
using UnityEngine;

namespace ZombieShooter
{
    [Serializable]
    public sealed class MeleeAttackSector
    {
        public AtomicVariable<bool> Enable = new(true);
        public AtomicValue<Transform> MeleePoint;
        public AtomicValue<float> MeleeRadius = new(0.3f);
        public AtomicEvent MeleeAttackEvent;
        public AtomicValue<int> Damage = new(1);
        
        public void OnEnable()
        {
            MeleeAttackEvent.Subscribe(OnMeleeAttack);
        }
        public void OnDisable()
        {
            MeleeAttackEvent.Unsubscribe(OnMeleeAttack);
        }

        private void OnMeleeAttack()
        {
            if(!Enable.Value)
                return;
            
            var colliders = Physics.OverlapSphere(MeleePoint.Value.position, MeleeRadius);
            foreach (var collider in colliders)
            {
                var entity = collider.gameObject.GetComponentInParent<IEntity>();
                if(entity == null)
                    continue;
                
                if(entity.TryGetEntityComponent(out IHealthComponent healthComponent))
                    healthComponent.DealDamage(Damage);
                
                break;
            }
        }
        
    }
}