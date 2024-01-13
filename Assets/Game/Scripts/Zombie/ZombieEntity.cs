using UnityEngine;
using Zenject;

namespace ZombieShooter
{
    public class ZombieEntity : UnitEntity
    {
        [SerializeField] private ZombieCore _zombieCore;
        [SerializeField] private UnitVFX _zombieVFX;
        [SerializeField] private UnitAudio _zombieAudio;

        protected override UnitCore UnitCore => _zombieCore;
        protected override UnitVFX UnitVFX => _zombieVFX;
        protected override UnitAudio UnitAudio => _zombieAudio;
        
        [Inject]
        public void Construct(Entity target)
        {
            _zombieCore.Init(this, target);
            _zombieVFX.Init(_zombieCore);
            _zombieAudio.Init(_zombieCore);
            
            base.Construct();
            
            AddEntityComponent(new MeleeAttackAnimationComponent(_zombieCore.MeleeAttackSector.MeleeAttackEvent));
        }
    }
}