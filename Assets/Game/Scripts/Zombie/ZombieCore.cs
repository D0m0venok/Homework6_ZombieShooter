using System;
using Atomic;
using UnityEngine;

namespace ZombieShooter
{
    [Serializable]
    public sealed class ZombieCore : UnitCore
    {
        public MeleeAttackSector MeleeAttackSector;
        public AgentsSection AgentSection;
        public AtomicValue<Collider> Collider;

        private Entity _target;
        
        public void Init(Entity entity, Entity target)
        {
            base.Init(entity);
            AgentSection.Init(entity, target);

            _target = target;
        }
        public override void OnEnable()
        {
            base.OnEnable();
            MeleeAttackSector.OnEnable();
            
            if (_target.TryGetEntityComponent(out IDeathComponent deathComponent))
                deathComponent.DeathEvent.Subscribe(OnTargetDeath);
        }
        public override void OnDisable()
        {
            base.OnDisable();
            MeleeAttackSector.OnDisable();
            
            if (_target.TryGetEntityComponent(out IDeathComponent deathComponent))
                deathComponent.DeathEvent.Unsubscribe(OnTargetDeath);
        }
        public override void Update()
        {
            base.Update();
            AgentSection.Update();
        }
    
        protected override void OnIsAliveValueChanged(bool isAlive)
        {
            base.OnIsAliveValueChanged(isAlive);
            AgentSection.Enable.Value = isAlive;
            Collider.Value.enabled = isAlive;
        }
        private void OnTargetDeath(Entity entity)
        {
            OnIsAliveValueChanged(false);
        }
    }
}