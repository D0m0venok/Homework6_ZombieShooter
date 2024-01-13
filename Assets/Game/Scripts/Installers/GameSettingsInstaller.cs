using UnityEngine;
using Zenject;

namespace ZombieShooter
{
    [CreateAssetMenu(menuName = "Game Settings")]
    public class GameSettingsInstaller : ScriptableObjectInstaller<GameSettingsInstaller>
    {
        [SerializeField] private ZombieSpawnSettings _zombieSpawnSettings;
        
        public override void InstallBindings()
        {
            Container.BindInstance(_zombieSpawnSettings);
        }
    }
}