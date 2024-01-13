using DG.Tweening;
using UnityEngine;
using Zenject;

namespace ZombieShooter
{
    public sealed class EndGamePopup : MonoBehaviour
    {
        [SerializeField] private float _duration = 1f;

        private GameManager _gameManager;

        [Inject]
        public void Construct(GameManager gameManager)
        {
            _gameManager = gameManager;
        }
        public void Show()
        {
            gameObject.SetActive(true);
            transform.DOScale(Vector3.one, _duration).From(Vector3.zero).OnComplete(() => _gameManager.SetState(GameState.FINISHED));
        }
    }
}