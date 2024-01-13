using ZombieShooter;

namespace Atomic
{
    public interface IEntity
    {
        T GetEntityComponent<T>()  where T : IComponent;

        bool TryGetEntityComponent<T>(out T element)  where T : IComponent;

        object[] GetAllComponents();
    }
}