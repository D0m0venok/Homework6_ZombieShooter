using Atomic;
using Extensions;

namespace ZombieShooter
{
    public sealed class ChargingMechanics
    {
        private readonly IAtomicValue<bool> _enable;
        private readonly IAtomicVariable<int> _charges;
        private readonly IAtomicValue<int> _maxCharges;
        private readonly Countdown _countdown;

        public ChargingMechanics(IAtomicValue<bool> enable, IAtomicVariable<int> charges, IAtomicValue<int> maxCharges,IAtomicValue<float> countdown)
        {
            _enable = enable;
            _charges = charges;
            _maxCharges = maxCharges;
            _countdown = new Countdown(countdown.Value);
        }

        public void OnEnable()
        {
            _countdown.Reset();
        }
        public void Update()
        {
            if(!_enable.Value || _charges.Value >= _maxCharges.Value)
                return;
            
            _countdown.Update();
            
            if(!_countdown.IsEnded)
                return;

            _charges.Value++;
            _countdown.Reset();
        }
    }
}