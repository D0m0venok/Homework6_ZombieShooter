using System;

namespace Atomic
{
    public interface IAtomicReadOnlyVariable<out T> : IAtomicValue<T>
    {
        public void Subscribe(Action<T> action);
        public void Unsubscribe(Action<T> action);
    }
}