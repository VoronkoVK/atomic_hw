using System;

namespace DefaultNamespace
{
    public interface IGameCycle
    {
        event Action OnWin;
        event Action OnLose;

        void Win();
        void Lose();
    }

    public class GameCycle : IGameCycle
    {
        public event Action OnWin;
        public event Action OnLose;

        public void Win()
        {
            OnWin?.Invoke();
        }

        public void Lose()
        {
            OnLose?.Invoke();
        }
    }
}