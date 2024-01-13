using System;
using Atomic;

namespace ZombieShooter
{
    [Serializable]
    public sealed class ChargeSection
    {
        public AtomicVariable<bool> Enable = new(true);
        public AtomicVariable<int> Charges = new(10);
        public AtomicValue<int> MaxCharges = new(10);
        public AtomicValue<float> CountdownCharging = new(2);
        
        private ChargingMechanics _chargingMechanics;
        
        public void Init()
        {
            _chargingMechanics = new ChargingMechanics(Enable, Charges, MaxCharges, CountdownCharging);
        }
        public void OnEnable()
        {
            _chargingMechanics.OnEnable();
        }
        public void Update()
        {
            _chargingMechanics.Update();
        }
    }
}