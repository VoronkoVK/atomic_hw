using System;
using SnakeGame;
using Zenject;

namespace DefaultNamespace
{
    public class GameOverUIController : IInitializable, IDisposable
    {
        private readonly IGameCycle _gameCycle;
        private readonly IGameUI _ui;

        public GameOverUIController(IGameCycle gameCycle, IGameUI ui)
        {
            _gameCycle = gameCycle;
            _ui = ui;
        }

        public void Initialize()
        {
            _gameCycle.OnWin += OnWin;
            _gameCycle.OnLose += OnLose;
        }

        public void Dispose()
        {
            _gameCycle.OnWin -= OnWin;
            _gameCycle.OnLose -= OnLose;
        }

        private void OnWin()
        {
            _ui.GameOver(true);
        }

        private void OnLose()
        {
            _ui.GameOver(false);
        }
    }
}