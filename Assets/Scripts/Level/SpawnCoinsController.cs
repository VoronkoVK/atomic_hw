using System;
using Modules;
using Zenject;

namespace DefaultNamespace
{
    public class SpawnCoinsController : IInitializable, IDisposable
    {
        private readonly ICoinsManager _coinsManager;
        private readonly IDifficulty _difficulty;
        private readonly int _coins;

        public SpawnCoinsController(ICoinsManager coinsManager, IDifficulty difficulty, LevelConfig levelConfig)
        {
            _coinsManager = coinsManager;
            _difficulty = difficulty;

            _coins = levelConfig.CoinsOnLevel;
        }

        public void Initialize()
        {
            _difficulty.OnStateChanged += OnDifficultyChanged;
            OnDifficultyChanged();
        }

        public void Dispose()
        {
            _difficulty.OnStateChanged -= OnDifficultyChanged;
        }

        private void OnDifficultyChanged()
        {
            _coinsManager.Spawn(_coins);
        }
    }
}