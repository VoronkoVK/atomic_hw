using UnityEngine;

namespace ShootEmUp
{
    public class FinishGameObserver : MonoBehaviour
    {
        [SerializeField] private GameManager _gameManager;
        [SerializeField] private Unit _player;


        private void OnEnable()
        {
            _player.OnHealthEmpty += OnPlayerDeath;
        }

        private void OnDisable()
        {
            _player.OnHealthEmpty -= OnPlayerDeath;
        }

        private void OnPlayerDeath(Unit player)
        {
            _gameManager.FinishGame();
        }
    }
}
