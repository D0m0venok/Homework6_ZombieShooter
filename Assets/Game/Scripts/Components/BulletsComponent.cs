using Atomic;

namespace ZombieShooter
{
    public sealed class BulletsComponent : IBulletsComponent
    {
        public IAtomicReadOnlyVariable<int> Bullets { get; }
        public IAtomicValue<int> MaxBullets { get; }

        public BulletsComponent(IAtomicReadOnlyVariable<int> bullets, IAtomicValue<int> maxBullets)
        {
            Bullets = bullets;
            MaxBullets = maxBullets;
        }
    }
}