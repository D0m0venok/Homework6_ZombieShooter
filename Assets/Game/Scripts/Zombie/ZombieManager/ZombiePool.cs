using Extensions;
using UnityEngine;
using Zenject;

namespace ZombieShooter
{
    public sealed class ZombiePool : GameObjectsPool<ZombieEntity>
    {
        private readonly GameManager _gameManager;
        
        public ZombiePool(DiContainer diContainer, ZombieSpawnSettings settings, Transform activeContainer, Transform disableContainer) : 
            base(diContainer, settings.EnemyPrefab, activeContainer, disableContainer, settings.InitialCount)
        {
            _gameManager = diContainer.Resolve<GameManager>();
        }
        
        public override ZombieEntity Get()
        {
            var zombie = base.Get();
            _gameManager.AddListener(zombie);
            return zombie;
        }
        public override void Put(ZombieEntity zombie)
        {
            _gameManager.RemoveListener(zombie);
            base.Put(zombie);
        }
        protected override ZombieEntity Create()
        {
            var zombie = base.Create();
            _diContainer.Inject(zombie);
            return zombie;
        }
    }
}