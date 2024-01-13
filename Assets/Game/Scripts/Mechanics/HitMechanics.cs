using Atomic;
using UnityEngine;

namespace ZombieShooter
{
    public sealed class HitMechanics
    {
        private readonly IAtomicVariable<int> _hitPoints;
        private readonly IAtomicEvent<int> _hitEvent;
        private readonly IAtomicAction<Entity> _deathEvent;
        private readonly Entity _entity;

        public HitMechanics(IAtomicVariable<int> hitPoints, IAtomicEvent<int> takeDamage, IAtomicAction<Entity> deathEvent, Entity entity)
        {
            _hitPoints = hitPoints;
            _hitEvent = takeDamage;
            _deathEvent = deathEvent;
            _entity = entity;
        }

        public void OnEnable()
        {
            _hitEvent.Subscribe(OnHit);
        }
        
        public void OnDisable()
        {
            _hitEvent.Unsubscribe(OnHit);
        }

        private void OnHit(int damage)
        {
            if(_hitPoints.Value <= 0)
                return;
            
            _hitPoints.Value = Mathf.Max(0, _hitPoints.Value - damage);
            
            if (_hitPoints.Value == 0)
                _deathEvent?.Invoke(_entity);
        }
    }
}