using Atomic;
using UnityEngine;
using Zenject;
using ZombieShooter;

namespace ShootEmUp
{
    public class BootstrapInstaller : MonoInstaller
    {
        [SerializeField] private GameManager _gameManager;
        [SerializeField] private GameManagerInstaller _gameManagerInstaller;
        [SerializeField] private Entity _characterEntity;
        
        public override void InstallBindings()
        {
            Container.Bind<GameManager>().FromInstance(_gameManager).AsSingle();
            Container.Bind<GameManagerInstaller>().FromInstance(_gameManagerInstaller).AsSingle();
            
            Container.BindInterfacesTo<CharacterEntity>().FromInstance(_characterEntity).AsCached();
            Container.Bind<Entity>().FromInstance(_characterEntity).AsSingle();

            Container.BindInterfacesTo<InputSystemManager>().AsSingle();
            Container.BindInterfacesTo<MoveController>().AsSingle();
            Container.BindInterfacesTo<LookAtController>().AsSingle();
            Container.BindInterfacesTo<FireController>().AsSingle();

            Container.Bind<CharacterDeathObserver>().AsSingle().NonLazy();
        }
    }
}
