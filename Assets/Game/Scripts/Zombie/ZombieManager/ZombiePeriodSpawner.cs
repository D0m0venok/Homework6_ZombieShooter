using Extensions;

namespace ZombieShooter
{
    public sealed class ZombiePeriodSpawner : IGameUpdateListener
    {
        private readonly ZombieManager _enemyManager;
        private readonly Countdown _countdown;
        
        public ZombiePeriodSpawner(ZombieManager enemyManager, float spawnDelay)
        {
            _enemyManager = enemyManager;
            _countdown = new Countdown(spawnDelay);
        }
        
        public void OnUpdate(float deltaTime)
        {
            _countdown.Update();
            if (!_countdown.IsEnded) 
                return;

            _enemyManager.SpawnEnemy();
            _countdown.Reset();
        }
    }
}