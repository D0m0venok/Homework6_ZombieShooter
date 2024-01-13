using System;
using UnityEngine;

namespace Extensions
{
    [Serializable]
    public sealed class Countdown
    {
        [SerializeField] private float _duration;
        [SerializeField] private float _currentTime;

        public bool IsEnded => _currentTime <= 0;

        public Countdown() { }
        public Countdown(float duration, float currentTime = 0)
        {
            _duration = duration;
            _currentTime = currentTime;
        }

        public void Update()
        {
            _currentTime -= Time.deltaTime;
        }
        public void Reset()
        {
            _currentTime = _duration;
        }
    }
}