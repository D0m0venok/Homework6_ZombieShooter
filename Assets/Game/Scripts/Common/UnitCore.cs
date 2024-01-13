using System;
using Atomic;

namespace ZombieShooter
{
    [Serializable]
    public class UnitCore
    {
        public HealthSection HealthSection;
        public MoveSection MoveSection;
        public LookAtSection LookAtSection;
        public AttackSection AttackSection;
        
        public virtual void Init(Entity entity)
        {
            HealthSection.Init(entity);
            MoveSection.Init(entity.transform);
            LookAtSection.Init(entity.transform);
            AttackSection.Init();
        }
        
        public virtual void OnEnable()
        {
            HealthSection.IsAlive.Subscribe(OnIsAliveValueChanged);
            
            HealthSection.OnEnable();
            MoveSection.OnEnable();
            AttackSection.OnEnable();
        }
        public virtual void OnDisable()
        {
            HealthSection.OnDisable();
            MoveSection.OnDisable();
            AttackSection.OnDisable();
            
            HealthSection.IsAlive.Unsubscribe(OnIsAliveValueChanged);
        }
        public virtual void Update()
        {
            MoveSection.Update();
            LookAtSection.Update();
            AttackSection.Update();
        }
        
        protected virtual void OnIsAliveValueChanged(bool isAlive)
        {
            MoveSection.Enable.Value = LookAtSection.Enable.Value = AttackSection.Enable.Value = isAlive;
        }
    }
}