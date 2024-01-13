using Atomic;
using UnityEngine;

namespace ZombieShooter
{
    public sealed class BulletCollisionMechanics
    {
        private readonly IAtomicValue<int> _damage;

        public BulletCollisionMechanics(IAtomicValue<int> damage)
        {
            _damage = damage;
        }

        public void OnCollisionEnter(Collision collider)
        {
            var entity = collider.gameObject.GetComponentInParent<IEntity>();
            
            if (entity != null)
                if (entity.TryGetEntityComponent(out IHealthComponent healthComponent))
                    healthComponent.DealDamage(_damage.Value);
        }
    }
}