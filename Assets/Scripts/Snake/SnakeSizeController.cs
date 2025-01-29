using System;
using DefaultNamespace;
using Modules;
using Zenject;

namespace DefaultNamespace
{
    public class SnakeSizeController : IInitializable, IDisposable
    {
        private readonly ICoinsManager _coinsManager;
        private readonly ISnake _snake;

        public SnakeSizeController(ICoinsManager coinsManager, ISnake snake)
        {
            _coinsManager = coinsManager;
            _snake = snake;
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
            _snake.Expand(coin.Bones);
        }
    }
}