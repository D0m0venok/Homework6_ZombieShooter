using UnityEngine;
using Zenject;

namespace ZombieShooter
{
    public class CharacterEntity : UnitEntity
    {
        [SerializeField] private CharacterCore _characterCore;
        [SerializeField] private CharacterVFX _characterVFX;
        [SerializeField] private CharacterAudio _characterAudio;

        protected override UnitCore UnitCore => _characterCore;
        protected override UnitVFX UnitVFX => _characterVFX;
        protected override UnitAudio UnitAudio => _characterAudio;

        [Inject]
        public void Construct(BulletSystem bulletSystem)
        {
            _characterCore.Init(bulletSystem, this);
            _characterVFX.Init(_characterCore);
            _characterAudio.Init(_characterCore);
            
            base.Construct();
            
            var chargeSection = _characterCore.ChargeSector;
            AddEntityComponent(new FireAnimationComponent(_characterCore.FireSection.FireEvent));
            AddEntityComponent(new BulletsComponent(chargeSection.Charges, chargeSection.MaxCharges));
        }
    }
}