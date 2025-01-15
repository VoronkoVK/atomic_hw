using System;

namespace DefaultNamespace
{
    public interface IScoreManager
    {
        event Action<int> OnScoreChanged;
        int Score { get; }
        void AddScore(int score);
    }

    public class ScoreManager : IScoreManager
    {
        public event Action<int> OnScoreChanged;
        public int Score { get; private set; }
        
        public void AddScore(int score)
        {
            Score += score;
            OnScoreChanged?.Invoke(Score);
        }
    }
}