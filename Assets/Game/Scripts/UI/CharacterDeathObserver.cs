namespace ZombieShooter
{
    public sealed class CharacterDeathObserver
    {
        private readonly EndGamePopup _endGamePopup;

        public CharacterDeathObserver(Entity entity, EndGamePopup endGamePopup)
        {
            _endGamePopup = endGamePopup;

            if (entity.TryGetEntityComponent(out IDeathComponent deathComponent))
                deathComponent.DeathEvent.Subscribe(OnCharacterDeath);
        }


        private void OnCharacterDeath(Entity entity)
        {
            _endGamePopup.Show();
            
            if (entity.TryGetEntityComponent(out IDeathComponent deathComponent))
                deathComponent.DeathEvent.Unsubscribe(OnCharacterDeath);
        }
    }
}