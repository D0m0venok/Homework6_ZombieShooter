using UnityEngine;

namespace ZombieShooter
{
    public sealed class LookAtController : IGameStartListener, IGameFinishListener
    {
        private readonly Entity _entity;
        private readonly IMousePositionsInput _mousePositions;
        
        public LookAtController(Entity entity, IMousePositionsInput mousePositions)
        {
            _entity = entity;
            _mousePositions = mousePositions;
        }

        public void OnStart()
        {
            _mousePositions.OnRotated += LookAt;
        }
        public void OnFinish()
        {
            _mousePositions.OnRotated -= LookAt;
        }

        private void LookAt(Vector3 point)
        {
            if (_entity.TryGetEntityComponent(out ILookAtComponent lookAtComponent))
                lookAtComponent.LookAt(point);
        }
    }
}