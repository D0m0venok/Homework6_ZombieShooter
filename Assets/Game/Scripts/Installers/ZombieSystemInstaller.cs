using UnityEngine;
using Zenject;

namespace ZombieShooter
{
    public class ZombieSystemInstaller : MonoInstaller
    {
        [SerializeField] private Transform _activeContainer;
        [SerializeField] private Transform _disableContainer;
        [SerializeField] private float _spawnDelay = 2f;
        [SerializeField] private Transform[] _spawnPositions;

        public override void InstallBindings()
        {
            Container.Bind<ZombiePool>().AsSingle().WithArguments(_activeContainer, _disableContainer);
            Container.Bind<ZombieManager>().AsSingle();
            Container.BindInterfacesAndSelfTo<ZombiePeriodSpawner>().AsCached().WithArguments(_spawnDelay);
            Container.Bind<ZombiePositions>().AsSingle().WithArguments(_spawnPositions);
        }
    }
}