using UnityEngine;
using Zenject;

namespace ZombieShooter
{
    public class GameSceneGUIInstaller : MonoInstaller
    {
        [SerializeField] private CharacterUI _characterUI;
        [SerializeField] private EndGamePopup _endGamePopup;
        
        public override void InstallBindings()
        {
            Container.Bind<CharacterUI>().FromInstance(_characterUI).AsSingle();
            Container.Bind<EndGamePopup>().FromInstance(_endGamePopup).AsSingle();
            Container.BindInterfacesTo<CharacterUIObserver>().AsSingle().NonLazy();
        }
    }
}