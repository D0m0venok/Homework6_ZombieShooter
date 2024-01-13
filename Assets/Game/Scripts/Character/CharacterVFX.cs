using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace ZombieShooter
{
    [Serializable]
    public class CharacterVFX : UnitVFX
    {
        [SerializeField] private ParticleSystem _fireVFX;

        private CharacterCore _character;

        public void Init(CharacterCore character)
        {
            base.Init(character);
            _character = character;
        }
        
        public override void OnEnable()
        {
            base.OnEnable();
            _character.FireSection.FireEvent.Subscribe(OnFire);
        }
        public override void OnDisable()
        {
            base.OnDisable();
            _character.FireSection.FireEvent.Unsubscribe(OnFire);
        }

        private void OnFire()
        {
            _fireVFX.transform.position = _character.FireSection.FirePoint.Value.position;
            _fireVFX.Play(true);
        }
    }
}