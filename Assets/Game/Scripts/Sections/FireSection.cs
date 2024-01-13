using System;
using Atomic;
using UnityEngine;

namespace ZombieShooter
{
    [Serializable]
    public sealed class FireSection
    {
        public AtomicVariable<bool> Enable = new(true);
        public FireEvent FireEvent;
        public SpawnBulletAction SpawnBulletAction;
        public AtomicValue<Transform> FirePoint;

        public void Init(BulletSystem bulletSystem, IAtomicVariable<int> charges)
        {
            FireEvent.Init(SpawnBulletAction, charges);
            SpawnBulletAction.Init(bulletSystem, FirePoint);
        }
    }
}