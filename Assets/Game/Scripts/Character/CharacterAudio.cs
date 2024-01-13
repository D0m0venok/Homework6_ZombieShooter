using System;
using UnityEngine;

namespace ZombieShooter
{
    [Serializable]
    public class CharacterAudio : UnitAudio
    {
        [SerializeField] private AudioSource _fireSource;
        
        private CharacterCore _characterCore;
        
        public void Init(CharacterCore characterCore)
        {
            base.Init(characterCore);
            _characterCore = characterCore;
        }
        
        public override void OnEnable()
        {
            base.OnEnable();
            _characterCore.FireSection.FireEvent.Subscribe(OnFired);
        }

        public override void OnDisable()
        {
            base.OnDisable();
            _characterCore.FireSection.FireEvent.Unsubscribe(OnFired);
        }
        
        private void OnFired()
        {
            _fireSource.PlayOneShot(_fireSource.clip);
        }
    }
}