using Atomic;
using UnityEngine;

namespace ZombieShooter
{
    public class AnimatorController
    {
        private static readonly int State = Animator.StringToHash("State");
        private static readonly int AttackTrigger = Animator.StringToHash("Attack");
        private static readonly int HitTrigger = Animator.StringToHash("Hit");

        private const int IDLE = 0;
        private const int MOVE = 1;
        private const int DEATH = 2;

        private readonly IAtomicFunction<bool> _isMoving;
        private readonly IAtomicValue<bool> _isAlive;
        private readonly IAtomicEvent _attackRequestEvent;
        private readonly IAtomicEvent<int> _hitEvent;
        private readonly Animator _animator;

        public AnimatorController(IAtomicFunction<bool> isMoving, IAtomicValue<bool> isAlive,
            IAtomicEvent<int> hitEvent, IAtomicEvent attackRequestEvent, Animator animator)
        {
            _isMoving = isMoving;
            _isAlive = isAlive;
            _attackRequestEvent = attackRequestEvent;
            _hitEvent = hitEvent;
            _animator = animator;
        }

        public void Update()
        {
            _animator.SetInteger(State, GetAnimationValue());
        }
        public void OnEnable()
        {
            _attackRequestEvent.Subscribe(OnAttack);
            _hitEvent.Subscribe(OnHit);
        }
        public void OnDisable()
        {
            _attackRequestEvent.Unsubscribe(OnAttack);
            _hitEvent.Unsubscribe(OnHit);
        }

        private void OnAttack()
        {
            _animator.SetTrigger(AttackTrigger);
        }
        private void OnHit(int damage)
        {
            _animator.SetTrigger(HitTrigger);
        }
        private int GetAnimationValue()
        {
            if (!_isAlive.Value)
            {
                return DEATH;
            }

            if (_isMoving.Value)
                return MOVE;

            return IDLE;
        }
    }
}