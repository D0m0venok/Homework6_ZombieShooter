using System;
using UnityEngine;

namespace ZombieShooter
{
    public interface IMoveInput
    {
        public event Action<Vector3> OnMoved;
    }
}