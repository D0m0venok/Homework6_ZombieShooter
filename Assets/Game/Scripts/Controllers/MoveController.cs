using UnityEngine;

namespace ZombieShooter
{
    public sealed class MoveController : IGameStartListener, IGameFinishListener
    {
        private readonly Entity _entity;
        private readonly IMoveInput _moveInput;
        
        public MoveController(Entity entity, IMoveInput moveInput)
        {
            _entity = entity;
            _moveInput = moveInput;
        }

        public void OnStart()
        {
            _moveInput.OnMoved += Move;
        }
        public void OnFinish()
        {
            _moveInput.OnMoved -= Move;
        }
        
        private void Move(Vector3 moveDirection)
        {
            if (_entity.TryGetEntityComponent(out IMoveComponent moveComponent))
                moveComponent.Move(moveDirection);
        }
    }
}