using System;
using Modules;
using UnityEngine;
using Zenject;

namespace DefaultNamespace
{
    public class CollisionCoinObserver : IInitializable, IDisposable
    {
        private readonly ICoinsManager _coinsManager;
        private readonly ISnake _snake;

        public CollisionCoinObserver(ICoinsManager coinsManager, ISnake snake)
        {
            _coinsManager = coinsManager;
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
            _coinsManager.TryCollect(pos);
        }
    }
}