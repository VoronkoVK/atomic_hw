using System;
using Modules;
using SnakeGame;
using Zenject;

namespace DefaultNamespace
{
    public class ScoreWidget : IInitializable, IDisposable
    {
        private readonly IScore _score;
        private readonly IGameUI _ui;

        public ScoreWidget(IScore score, IGameUI ui)
        {
            _score = score;
            _ui = ui;
        }

        public void Initialize()
        {
            _score.OnStateChanged += UpdateScore;
            UpdateScore(_score.Current);
        }

        public void Dispose()
        {
            _score.OnStateChanged -= UpdateScore;
        }

        private void UpdateScore(int score)
        {
            _ui.SetScore(score.ToString());
        }
    }
}