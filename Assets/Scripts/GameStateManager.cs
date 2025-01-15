using UnityEngine;

namespace DefaultNamespace
{
    public interface IGameStateManager
    {
        void Win();
        void Lose();
    }

    public class GameStateManager : IGameStateManager
    {
        private readonly GameObject _winScreen;
        private readonly GameObject _loseScreen;

        public GameStateManager(GameObject winScreen, GameObject loseScreen)
        {
            _winScreen = winScreen;
            _loseScreen = loseScreen;
        }

        public void Win()
        {
            Time.timeScale = 0;
            _winScreen.SetActive(true);
        }

        public void Lose()
        {
            Time.timeScale = 0;
            _loseScreen.SetActive(true);
        }
    }
}