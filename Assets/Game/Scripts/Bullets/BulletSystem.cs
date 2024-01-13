using UnityEngine;

namespace ZombieShooter
{
    public sealed class BulletSystem
    {
        private readonly BulletPool _pool;

        public BulletSystem(BulletPool pool)
        {
            _pool = pool;
        }
        
        public void FlyBullet(Vector3 position, Vector3 direction)
        {
            var bullet = _pool.Get();
            bullet.SetBullet(_pool, position);
            bullet.MoveSection.MoveDirection.Value = direction;
        }
    }
}