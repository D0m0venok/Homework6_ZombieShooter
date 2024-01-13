using System;
using Atomic;
using UnityEngine;

namespace ZombieShooter
{
    [Serializable]
    public class UnitAudio
    {
        [SerializeField] private AudioSource _hitSource;
        
        private UnitCore _unitCore;
        
        public virtual void Init(UnitCore unitCore)
        {
            _unitCore = unitCore;
        }
        public virtual void OnEnable()
        {
            _unitCore.HealthSection.DeathEvent.Subscribe(OnDeath);
            _unitCore.HealthSection.HitEvent.Subscribe(OnHit);
        }
        public virtual void OnDisable()
        {
            _unitCore.HealthSection.DeathEvent.Unsubscribe(OnDeath);
            _unitCore.HealthSection.HitEvent.Unsubscribe(OnHit);
        }
        
        private void OnHit(int damage)
        {
            _hitSource.PlayOneShot(_hitSource.clip);
        }
        private void OnDeath(IEntity entity)
        {
            _hitSource.PlayOneShot(_hitSource.clip);
        }
    }
}