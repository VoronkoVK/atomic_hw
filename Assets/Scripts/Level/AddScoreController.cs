using System;
using Modules;
using Zenject;

namespace DefaultNamespace
{
    public class AddScoreController : IInitializable, IDisposable
    {
        private readonly IScore _score;
        private readonly ICoinsManager _coinsManager;

        public AddScoreController(IScore score, ICoinsManager coinsManager)
        {
            _score = score;
            _coinsManager = coinsManager;
        }

        public void Initialize()
        {
            _coinsManager.OnCoinCollected += OnCoinCollected;
        }

        public void Dispose()
        {
            _coinsManager.OnCoinCollected -= OnCoinCollected;
        }

        private void OnCoinCollected(Coin coin)
        {
            _score.Add(coin.Score);
        }
    }
}