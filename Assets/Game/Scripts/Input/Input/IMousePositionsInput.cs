using System;
using UnityEngine;

namespace ZombieShooter
{
    public interface IMousePositionsInput
    {
        public event Action<Vector3> OnRotated;
    }
}