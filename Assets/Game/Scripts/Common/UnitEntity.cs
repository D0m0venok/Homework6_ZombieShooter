namespace ZombieShooter
{
    public abstract class UnitEntity : Entity, IGameUpdateListener,
        IGameAddedListener, IGameRemovedListener
    {
        protected abstract UnitCore UnitCore { get; }
        protected abstract UnitVFX UnitVFX { get; }
        protected abstract UnitAudio UnitAudio { get; }
        
        public virtual void Construct()
        {
            var healthSection = UnitCore.HealthSection;
            var moveSection = UnitCore.MoveSection;
            AddEntityComponent(new HealthComponent(healthSection.HitPoints, healthSection.HitEvent, healthSection.IsAlive));
            AddEntityComponent(new MoveComponent(moveSection.MoveDirection, moveSection.Enable));
            AddEntityComponent(new LookAtComponent(UnitCore.LookAtSection.LookAtPoint));
            AddEntityComponent(new AttackComponent(UnitCore.AttackSection.AttackEvent));
            AddEntityComponent(new DeathComponent(healthSection.DeathEvent));
        }
        public virtual void OnUpdate(float deltaTime)
        {
            UnitCore.Update();
            UnitVFX.Update();
        }
        public virtual void OnAdded()
        {
            UnitCore.OnEnable();
            UnitVFX.OnEnable();
            UnitAudio.OnEnable();
        }
        public virtual void OnRemoved()
        {
            UnitCore.OnDisable();
            UnitVFX.OnDisable();
            UnitAudio.OnDisable();
        }
    }
}
