using System;
using Atomic;

namespace ZombieShooter
{
    [Serializable]
    public sealed class HealthSection
    {
        public AtomicEvent<IEntity> DeathEvent;
        public AtomicEvent<int> HitEvent;
        public AtomicVariable<int> HitPoints = new(5);
        public AtomicVariable<bool> IsAlive = new(true);
        
        private HitMechanics _takeDamageMechanics;
        private DeathMechanics _deathMechanics;
        private int _startHitPoints;

        public void Init(IEntity entity)
        {
            _takeDamageMechanics = new HitMechanics(HitPoints, HitEvent, DeathEvent, entity);
            _deathMechanics = new DeathMechanics(IsAlive, DeathEvent);

            _startHitPoints = HitPoints;
        }
        
        public void OnEnable()
        {
            HitPoints.Value = _startHitPoints;
            IsAlive.Value = true;
            
            _takeDamageMechanics.OnEnable();
            _deathMechanics.OnEnable();
        }
        public void OnDisable()
        {
            _takeDamageMechanics.OnDisable();
            _deathMechanics.OnDisable();
        }
    }
}