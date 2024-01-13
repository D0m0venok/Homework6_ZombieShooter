using System;
using UnityEngine;

namespace Atomic
{
    [Serializable]
    public class AtomicValue<T> : IAtomicValue<T>
    {
        public static implicit operator T(AtomicValue<T> c) => c.Value;
        
        [SerializeField] private T _value;
        public T Value => _value;

        public AtomicValue(T value)
        {
            _value = value;
        }
    }
}