using UnityEngine;
using Zenject;

namespace ZombieShooter
{
    public class BulletInstaller : MonoInstaller
    {
        
        [SerializeField] private BulletPool.BulletPoolSettings _bulletPoolSettings;
        [SerializeField] private Transform _activeContainer;
        [SerializeField] private Transform _disableContainer;

        public override void InstallBindings()
        {
            
            Container.Bind<BulletPool.BulletPoolSettings>().FromInstance(_bulletPoolSettings).AsSingle();
            
            Container.Bind<BulletPool>().AsSingle().WithArguments(_activeContainer, _disableContainer);
            Container.Bind<BulletSystem>().AsSingle();
        }
    }
}