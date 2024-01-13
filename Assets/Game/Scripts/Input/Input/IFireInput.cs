using System;

namespace ZombieShooter
{
    public interface IFireInput
    {
        public event Action OnFired;
    }
}