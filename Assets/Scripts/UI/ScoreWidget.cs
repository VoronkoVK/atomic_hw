using System;
using TMPro;
using Zenject;

namespace DefaultNamespace.UI
{
    public class ScoreWidget : IInitializable, IDisposable
    {
        private readonly TMP_Text _scoreText;
        private readonly IScoreManager _scoreManager;

        public ScoreWidget(TMP_Text scoreText, IScoreManager scoreManager)
        {
            _scoreText = scoreText;
            _scoreManager = scoreManager;
        }

        public void Initialize()
        {
            _scoreManager.OnScoreChanged += UpdateScore;
            UpdateScore(_scoreManager.Score);
        }

        public void Dispose()
        {
            _scoreManager.OnScoreChanged -= UpdateScore;
        }

        private void UpdateScore(int score)
        {
            _scoreText.text = $"Score: {score}";
        }
    }
}