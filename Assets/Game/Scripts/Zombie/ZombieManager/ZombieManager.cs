using System;
using Atomic;
using DG.Tweening;
using UnityEngine;

namespace ZombieShooter
{
    public sealed class ZombieManager
    {
        private readonly ZombiePositions _enemyPositions;
        private readonly ZombiePool _pool;
        private readonly float _putDelay = 2f;
        private readonly AtomicVariable<int> _kills = new(0);

        public IAtomicReadOnlyVariable<int> Kills => _kills;
        
        public ZombieManager(ZombiePool pool, ZombiePositions enemyPositions)
        {
            _enemyPositions = enemyPositions;
            _pool = pool;
        }
        
        public void SpawnEnemy()
        {
            var spawnPosition = _enemyPositions.RandomSpawnPosition();
            var zombie = _pool.Get();
            zombie.transform.position = spawnPosition.position;
            if (zombie.TryGetEntityComponent(out IDeathComponent deathComponent))
                deathComponent.DeathEvent.Subscribe(OnKilled);
        }

        private void OnKilled(Entity entity)
        {
            _kills.Value++;
            var zombie = (ZombieEntity)entity;
            if (zombie.TryGetEntityComponent(out IDeathComponent deathComponent))
                deathComponent.DeathEvent.Unsubscribe(OnKilled);

            var scale = zombie.transform.localScale;
            zombie.transform.DOScale(Vector3.zero, _putDelay).SetDelay(_putDelay).OnComplete(() =>
            {
                _pool.Put(zombie);
                zombie.transform.localScale = scale;
            });
        }
    }

    [Serializable]
    public class ZombieSpawnSettings
    {
        public int InitialCount = 4;
        public ZombieEntity EnemyPrefab;
    }
}