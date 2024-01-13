using System;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

namespace ZombieShooter
{
    public sealed class InputSystemManager : IMoveInput, IFireInput, IMousePositionsInput,
        IGameStartListener, IGameFinishListener,
        IGamePauseListener, IGameResumeListener,
        IGameUpdateListener
    {
        public event Action OnFired = delegate {};
        public event Action<Vector3> OnMoved = delegate {};
        public event Action<Vector3> OnRotated = delegate {};

        private Camera _camera;
        private Controls _controls;

        public void OnStart()
        {
            _camera = Camera.main;
            
            _controls = new Controls();
            
            _controls.Enable();
        }
        public void OnFinish()
        {
            _controls.Disable();
        }
        public void OnPause()
        {
            _controls.Disable();
        }
        public void OnResume()
        {
            _controls.Enable();
        }
        public void OnUpdate(float deltaTime)
        {
            if (_controls.Main.Fire.inProgress)
                OnFired();
            
            var position = _controls.Main.Move.ReadValue<Vector2>();
            OnMoved(new Vector3(position.x, 0, position.y));

            var point = _controls.Main.LookAt.ReadValue<Vector2>();
            if (TryConvertMousePositionToDirection(point, out var direction))
                OnRotated(direction);
        }

        private bool TryConvertMousePositionToDirection(Vector2 point, out Vector3 direction)
        {
            var position = _camera.transform.position;
            var worldPoint = _camera.ScreenToWorldPoint(new Vector3(point.x, point.y, position.y));

            if (Physics.Raycast(position, worldPoint - position, out var info, 20f, LayerMask.GetMask("Ground")))
            {
                direction = info.point;
                return true;
            }

            direction = Vector3.zero;
            return false;
        }
    }
}