namespace Atomic
{
    public interface IAtomicVariable<T> : IAtomicReadOnlyVariable<T>
    {
        new T Value { get; set; }
    }
}