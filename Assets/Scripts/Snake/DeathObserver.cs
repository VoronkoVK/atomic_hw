using System;
using Modules;
using SnakeGame;
using UnityEngine;
using Zenject;

namespace DefaultNamespace
{
    public class DeathObserver : IInitializable, IDisposable
    {
        private readonly ISnake _snake;
        private readonly IWorldBounds _bounds;
        private readonly IGameCycle _gameCycle;
        
        public DeathObserver(ISnake snake, IWorldBounds bounds, IGameCycle gameCycle)
        {
            _snake = snake;
            _bounds = bounds;
            this._gameCycle = gameCycle;
        }

        public void Initialize()
        {
            _snake.OnSelfCollided += Death;
            _snake.OnMoved += CheckBoundCollision;
        }

        public void Dispose()
        {
            _snake.OnSelfCollided -= Death;
            _snake.OnMoved -= CheckBoundCollision;
        }

        private void CheckBoundCollision(Vector2Int pos)
        {
            if (!_bounds.IsInBounds(pos))
            {
                Death();
            }
        }

        private void Death()
        {
            _gameCycle.Lose();
        }
    }
}