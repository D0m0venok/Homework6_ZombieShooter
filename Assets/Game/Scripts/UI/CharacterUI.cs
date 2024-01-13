using TMPro;
using UnityEngine;

namespace ZombieShooter
{
    public sealed class CharacterUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _hitPointsText;
        [SerializeField] private TextMeshProUGUI _bulletsText;
        [SerializeField] private TextMeshProUGUI _killsText;

        public void SetHitPoints(string hitPoints)
        {
            _hitPointsText.text = $"HIT POINTS: {hitPoints}";
        }
        public void SetBullets(string bullets, string maxBullets)
        {
            _bulletsText.text = $"BULLETS: {bullets}/{maxBullets}";
        }
        public void SetKills(string kills)
        {
            _killsText.text = $"KILLS: {kills}";
        }
    }
}