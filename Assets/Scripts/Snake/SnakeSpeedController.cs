using System;
using DefaultNamespace;
using Modules;
using Zenject;

namespace DefaultNamespace
{
    public class SnakeSpeedController : IInitializable, IDisposable
    {
        private readonly IDifficulty _difficulty;
        private readonly ISnake _snake;

        public SnakeSpeedController(IDifficulty difficulty, ISnake snake)
        {
            _difficulty = difficulty;
            _snake = snake;
        }

        public void Initialize()
        {
            _difficulty.OnStateChanged += OnDifficultyChanged;
        }

        public void Dispose()
        {
            _difficulty.OnStateChanged -= OnDifficultyChanged;

        }

        private void OnDifficultyChanged()
        {
            _snake.SetSpeed(_difficulty.Current);
        }
    }
}