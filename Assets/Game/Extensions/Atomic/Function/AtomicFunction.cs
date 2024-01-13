using System;
using Sirenix.OdinInspector;

namespace Atomic
{
    [Serializable]
    public sealed class AtomicFunction<TResult> : IAtomicFunction<TResult>
    {
        private Func<TResult> _func;

        [ShowInInspector, ReadOnly]
        public TResult Value => _func != null ? _func.Invoke() : default;

        public AtomicFunction()
        {
        }

        public AtomicFunction(Func<TResult> func)
        {
            _func = func;
        }

        public TResult Invoke()
        {
            return _func != null ? _func.Invoke() : default;
        }
    }

    [Serializable]
    public sealed class AtomicFunction<T, TResult> : IAtomicFunction<T, TResult>
    {
        private Func<T, TResult> _func;

        public AtomicFunction()
        {
        }

        public AtomicFunction(Func<T, TResult> func)
        {
            _func = func;
        }

        [Button]
        public TResult Invoke(T args)
        {
            return _func.Invoke(args);
        }
    }
}