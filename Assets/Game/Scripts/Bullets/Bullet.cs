using Atomic;
using Extensions;
using UnityEngine;

namespace ZombieShooter
{
    [RequireComponent(typeof(Collider))]
    public sealed class Bullet : MonoBehaviour , IGameStartListener, 
        IGameUpdateListener, IGameAddedListener
    {
        public MoveSection MoveSection;

        public AtomicValue<int> Damage = new(1);
        public AtomicValue<float> LifeTime = new(5);
        
        private BulletCollisionMechanics _bulletCollisionMechanics;

        private Countdown _countdown;
        private BulletPool _pool;

        private void OnCollisionEnter(Collision other)
        {
            _bulletCollisionMechanics.OnCollisionEnter(other);   
            _pool.Put(this);
        }
        
        public void OnStart()
        {
            MoveSection.Init(transform);
            
            _bulletCollisionMechanics = new BulletCollisionMechanics(Damage);
            _countdown = new Countdown(LifeTime.Value);
        }
        public void OnUpdate(float deltaTime)
        {
            MoveSection.Update();
            
            _countdown.Update();
            
            if(!_countdown.IsEnded)
                return;
            
            _pool.Put(this);
        }
        public void OnAdded()
        {
            _countdown.Reset();
        }
        public void SetBullet(BulletPool pool, Vector3 position)
        {
            _pool = pool;
            transform.position = position;
        }
    }
}