using System;
using Extensions;
using UnityEngine;
using Zenject;

namespace ZombieShooter
{
    public sealed class BulletPool : GameObjectsPool<Bullet>
    {
        private readonly GameManager _gameManager;

        public BulletPool(DiContainer diContainer, BulletPoolSettings settings, Transform activeContainer, Transform disableContainer) :
            base(diContainer, settings.BulletPrefab, activeContainer, disableContainer, settings.InitialCount)
        {
            _gameManager = diContainer.Resolve<GameManager>();
        }
            
        public override Bullet Get()
        {
            var zombie = base.Get();
            _gameManager.AddListener(zombie);
            return zombie;
        }
        public override void Put(Bullet zombie)
        {
            _gameManager.RemoveListener(zombie);
            base.Put(zombie);
        }
        protected override Bullet Create()
        {
            var bullet = base.Create();
            bullet.OnStart();
            return bullet;
        }
        
        [Serializable]
        public class BulletPoolSettings
        {
            public int InitialCount = 20;
            public Bullet BulletPrefab;
        }
    }
}