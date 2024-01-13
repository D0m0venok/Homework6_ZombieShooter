using System;
using Atomic;

namespace ZombieShooter
{
    [Serializable]
    public sealed class AgentsSection
    {
        public AtomicVariable<bool> Enable = new(true);
        public AtomicValue<float> PositionInaccuracy = new (1.75f);

        private ZombieMoveAgent _zombieMoveAgent;
        private ZombieAttackAgent _zombieAttackAgent;

        public void Init(Entity entity, Entity target)
        {
            _zombieMoveAgent = new ZombieMoveAgent(entity, target.transform, PositionInaccuracy);
            _zombieAttackAgent = new ZombieAttackAgent(entity, _zombieMoveAgent.IsReached);
        }
        public void Update()
        {
            if(!Enable.Value)
                return;
            
            _zombieAttackAgent.Update();
            _zombieMoveAgent.Update();
        }
    }
}