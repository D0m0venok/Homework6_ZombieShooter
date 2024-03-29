using System.Collections.Generic;
using UnityEngine;
using ZombieShooter;

namespace Atomic
{
    public class Entity : MonoBehaviour, IEntity
    {
        private readonly List<object> _components = new();
        
        public void AddEntityComponent<T>(T element) where T : IComponent
        {
            _components.Add(element);
        }

        public T GetEntityComponent<T>() where T : IComponent
        {
            for (int i = 0, count = _components.Count; i < count; i++)
            {
                if (_components[i] is T result)
                    return result;
            }

            return default;
        }
        public bool TryGetEntityComponent<T>(out T element) where T : IComponent
        {
            for (int i = 0, count = _components.Count; i < count; i++)
            {
                if (_components[i] is T result)
                {
                    element = result;
                    return true;
                }
            }

            element = default;
            return false;
        }
        public object[] GetAllComponents()
        {
            return _components.ToArray();
        }
    }
}