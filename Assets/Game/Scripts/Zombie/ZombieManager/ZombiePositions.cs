using UnityEngine;
using Zenject;

namespace ZombieShooter
{
    public sealed class ZombiePositions
    {
        private Transform[] _spawnPositions;
        
        [Inject]
        public void Construct(Transform[] spawnPositions)
        {
            _spawnPositions = spawnPositions;
        }
        public Transform RandomSpawnPosition()
        {
            return RandomTransform(_spawnPositions);
        }

        private static Transform RandomTransform(Transform[] transforms)
        {
            var index = Random.Range(0, transforms.Length);
            return transforms[index];
        }
    }
}