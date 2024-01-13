namespace ZombieShooter
{
    public sealed class CharacterUIObserver : IGameFinishListener
    {
        private readonly Entity _character;
        private readonly CharacterUI _characterUI;
        private readonly ZombieManager _zombieManager;
        private readonly int _maxBullets;

        public CharacterUIObserver(Entity character, CharacterUI characterUI, ZombieManager zombieManager)
        {
            _character = character;
            _characterUI = characterUI;
            _zombieManager = zombieManager;

            if (_character.TryGetEntityComponent(out IHealthComponent healthComponent))
            {
                OnHitPointsChanged(healthComponent.HitPoints.Value);
                healthComponent.HitPoints.Subscribe(OnHitPointsChanged);
            }

            if (_character.TryGetEntityComponent(out IBulletsComponent bulletsComponent))
            {
                _maxBullets = bulletsComponent.MaxBullets.Value;
                OnBulletsCountChanged(bulletsComponent.Bullets.Value);
                bulletsComponent.Bullets.Subscribe(OnBulletsCountChanged);
            }
                
            OnKilled(_zombieManager.Kills.Value);
            _zombieManager.Kills.Subscribe(OnKilled);
        }
        public void OnFinish()
        {
            if (_character.TryGetEntityComponent(out IHealthComponent healthComponent))
                healthComponent.HitPoints.Unsubscribe(OnHitPointsChanged);
            if (_character.TryGetEntityComponent(out IBulletsComponent bulletsComponent))
                bulletsComponent.Bullets.Unsubscribe(OnBulletsCountChanged);
            
            _zombieManager.Kills.Unsubscribe(OnKilled);
        }

        private void OnHitPointsChanged(int hitPoints)
        {
            _characterUI.SetHitPoints(hitPoints.ToString());
        }
        private void OnBulletsCountChanged(int bullets)
        {
            _characterUI.SetBullets(bullets.ToString(), _maxBullets.ToString());
        }
        private void OnKilled(int kills)
        {
            _characterUI.SetKills(kills.ToString());
        }
    }
}