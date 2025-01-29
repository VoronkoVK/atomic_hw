using System;
using Modules;
using Zenject;

namespace DefaultNamespace
{
    public class ChangeLevelController : IInitializable, IDisposable
    {
        private readonly ICoinsManager _coinsManager;
        private readonly IGameCycle _gameCycle;
        private readonly IDifficulty _difficulty;

        public ChangeLevelController(ICoinsManager coinsManager, IGameCycle gameCycle, IDifficulty difficulty)
        {
            _coinsManager = coinsManager;
            _gameCycle = gameCycle;
            _difficulty = difficulty;
        }

        public void Initialize()
        {
            _coinsManager.OnAllCoinsCollected += NextLevel;
            NextLevel();
        }

        public void Dispose()
        {
            _coinsManager.OnAllCoinsCollected -= NextLevel;
        }

        private void NextLevel()
        {
            var result = _difficulty.Next(out _);
            if (!result)
            {
                _gameCycle.Win();
            }
        }
    }
}