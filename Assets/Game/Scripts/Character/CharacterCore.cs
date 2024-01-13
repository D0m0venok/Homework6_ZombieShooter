using System;

namespace ZombieShooter
{
    [Serializable]
    public sealed class CharacterCore : UnitCore
    {
        public FireSection FireSection;
        public ChargeSection ChargeSector;

        public void Init(BulletSystem bulletSystem, Entity entity)
        {
            base.Init(entity);
            AttackSection.Init(() => ChargeSector.Charges > 0);
            FireSection.Init(bulletSystem, ChargeSector.Charges);
            ChargeSector.Init();
        }
        public override void OnEnable()
        {
            base.OnEnable();
            ChargeSector.OnEnable();
        }
        public override void Update()
        {
            base.Update();
            ChargeSector.Update();
        }
        
        protected override void OnIsAliveValueChanged(bool isAlive)
        {
            base.OnIsAliveValueChanged(isAlive);
            FireSection.Enable.Value = isAlive;
        }
    }
}