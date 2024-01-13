using Atomic;
using UnityEngine;

namespace ZombieShooter
{
    public interface IComponent { }
    public interface IAttackComponent : IComponent
    {
        void Attack();
    }
    public interface IFireAnimationComponent : IComponent
    {
        void Fire();
    }
    public interface IMeleeAttackAnimationComponent : IComponent
    {
        void MeleeAttack();
    }
    public interface ILookAtComponent : IComponent
    {
        void LookAt(Vector3 point);
    }
    public interface IMoveComponent : IComponent
    {
        void Move(Vector3 moveDirection);
        void EnableMove();
        void DisableMove();
    }
    public interface IHealthComponent : IComponent
    {
        public IAtomicVariable<int> HitPoints { get; }
        public IAtomicValue<bool> IsAlive { get; }
        public void DealDamage(int damage);
    }
    public interface IBulletsComponent : IComponent
    {
        public IAtomicReadOnlyVariable<int> Bullets { get; }
        public IAtomicValue<int> MaxBullets { get; }
    }

    public interface IDeathComponent : IComponent
    {
        public IAtomicEvent<IEntity> DeathEvent { get; }
    }
}