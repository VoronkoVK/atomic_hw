using System;
using Modules;
using SnakeGame;
using UnityEngine;
using Zenject;

namespace DefaultNamespace.Observers
{
    public class DeathObserver : IInitializable, IDisposable
    {
        private readonly ISnake _snake;
        private readonly IWorldBounds _bounds;
        private readonly IGameStateManager gameStateManager;
        
        public DeathObserver(ISnake snake, IWorldBounds bounds, IGameStateManager gameStateManager)
        {
            _snake = snake;
            _bounds = bounds;
            this.gameStateManager = gameStateManager;
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
            gameStateManager.Lose();
        }
    }
}