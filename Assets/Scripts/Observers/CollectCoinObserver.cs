using System;
using Modules;
using UnityEngine;
using Zenject;

namespace DefaultNamespace.Observers
{
    public class CollectCoinObserver : IInitializable, IDisposable
    {
        private readonly ICoinsManager _coinsManager;
        private readonly IScoreManager _scoreManager;
        private readonly ISnake _snake;

        public CollectCoinObserver(ICoinsManager coinsManager, IScoreManager scoreManager, ISnake snake)
        {
            _coinsManager = coinsManager;
            _scoreManager = scoreManager;
            _snake = snake;
        }

        public void Initialize()
        {
            _snake.OnMoved += CheckCollision;
        }

        public void Dispose()
        {
            _snake.OnMoved -= CheckCollision;
        }

        private void CheckCollision(Vector2Int pos)
        {
            var coins = _coinsManager.GetLevelCoins();
            foreach (var coin in coins)
            {
                if (coin.Position == pos)
                {
                    CollectCoin(coin);
                }
            }
        }

        private void CollectCoin(Coin coin)
        {
            _snake.Expand(coin.Bones);
            _scoreManager.AddScore(coin.Score);
            _coinsManager.Collect(coin);
        }
    }
}