using System;
using Modules;
using Zenject;

namespace DefaultNamespace
{
    public interface ILevelManager
    {
        event Action<int, int> OnLevelStarted;
        int CurrentLevel { get; }
        int MaxLevel { get; }
    }

    public class LevelManager : IInitializable, IDisposable, ILevelManager
    {
        public event Action<int, int> OnLevelStarted;
        
        public int CurrentLevel { get; private set; }
        public int MaxLevel { get; }

        private readonly ICoinsManager _coinsManager;
        private readonly IGameStateManager _gameStateManager;
        private readonly ISnake _snake;
        private readonly int _coinsOnLevel;

        public LevelManager(ICoinsManager coinsManager, IGameStateManager gameStateManager, ISnake snake,
            LevelConfig config)
        {
            _coinsManager = coinsManager;
            _gameStateManager = gameStateManager;
            _snake = snake;
            
            CurrentLevel = config.StartLevel;
            MaxLevel = config.FinishLevel;
            _coinsOnLevel = config.CoinsOnLevel;
        }

        public void Initialize()
        {
            _coinsManager.OnAllCoinsCollected += FinishLevel;
            StartLevel();
        }

        public void Dispose()
        {
            _coinsManager.OnAllCoinsCollected -= FinishLevel;
        }

        private void StartLevel()
        {
            _coinsManager.Spawn(_coinsOnLevel);
            _snake.SetSpeed(CurrentLevel);
            OnLevelStarted?.Invoke(CurrentLevel, MaxLevel);
        }

        private void FinishLevel()
        {
            if (CurrentLevel >= MaxLevel)
            {
                _gameStateManager.Win();
            }
            else
            {
                CurrentLevel++;
                StartLevel();
            }
        }
    }
}