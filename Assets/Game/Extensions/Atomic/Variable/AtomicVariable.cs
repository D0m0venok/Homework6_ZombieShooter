using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Atomic
{
    [Serializable]
    public class AtomicVariable<T> : IAtomicVariable<T>
    {
        public static implicit operator T(AtomicVariable<T> c) => c.Value;
        
        private event Action<T> _event;

        public void Subscribe(Action<T> action)
        {
            _event += action;
        }
        
        public void Unsubscribe(Action<T> action)
        {
            _event -= action;
        }

        [OnValueChanged("OnValueChangedInEditor")]
        [SerializeField]
        private T _value;

        public T Value
        {
            get => _value;
            set
            {
                _value = value;
                _event?.Invoke(value);
            }
        }

        public AtomicVariable(T value)
        {
            _value = value;
        }

#if UNITY_EDITOR
        private void OnValueChangedInEditor(T _)
        {
            _event?.Invoke(_value);
        }
#endif
    }
}