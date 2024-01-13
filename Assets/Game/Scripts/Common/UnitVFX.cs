using System;
using UnityEngine;

namespace ZombieShooter
{
    [Serializable]
    public class UnitVFX
    {
        [SerializeField] protected Animator _animator;
        [SerializeField] protected ParticleSystem _hitVFX;

        private UnitCore _unitCore;
        private AnimatorController _animatorController;

        public virtual void Init(UnitCore unit)
        {
            _unitCore = unit;
            _animatorController = new AnimatorController(unit.MoveSection.IsMoving, unit.HealthSection.IsAlive,
                unit.HealthSection.HitEvent, unit.AttackSection.AttackEvent, _animator);
        }
        public virtual void OnEnable()
        {
            _animatorController.OnEnable();

            _unitCore.HealthSection.HitEvent.Subscribe(OnHit);
        }
        public virtual void OnDisable()
        {
            _animatorController.OnDisable();

            _unitCore.HealthSection.HitEvent.Unsubscribe(OnHit);
        }
        public virtual void Update()
        {
            _animatorController.Update();
        }

        protected virtual void OnHit(int value)
        {
            _hitVFX.Play(true);
        }
    }
}