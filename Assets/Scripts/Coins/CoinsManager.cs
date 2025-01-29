using System;
using System.Collections.Generic;
using ModestTree;
using Modules;
using SnakeGame;
using UnityEngine;

namespace DefaultNamespace
{
    public interface ICoinsManager
    {
        event Action OnAllCoinsCollected;
        event Action<Coin> OnCoinCollected;

        void Spawn(int amount);

        void TryCollect(Vector2Int position);
    }

    public class CoinsManager : ICoinsManager
    {
        public event Action OnAllCoinsCollected;
        public event Action<Coin> OnCoinCollected;

        private readonly CoinsPool _coinsPool;
        private readonly IWorldBounds _worldBounds;

        private List<Coin> _coins = new();

        public CoinsManager(CoinsPool coinsPool, IWorldBounds worldBounds)
        {
            _coinsPool = coinsPool;
            _worldBounds = worldBounds;
        }

        public void Spawn(int amount)
        {
            for (var i = 0; i < amount; i++)
            {
                var pos = _worldBounds.GetRandomPosition();
                var coin = _coinsPool.Spawn(pos);
                _coins.Add(coin);
            }
        }

        public void TryCollect(Vector2Int position)
        {
            var toRemove = new List<Coin>();
            foreach (var coin in _coins)
            {
                if (coin.Position == position)
                {
                    Collect(coin);
                    toRemove.Add(coin);
                }
            }
            
            _coins.RemoveAll(coin => toRemove.Contains(coin));
            if (_coins.IsEmpty())
            {
                OnAllCoinsCollected?.Invoke();
            }
        }

        private void Collect(Coin coin)
        {
            _coinsPool.Despawn(coin);
            OnCoinCollected?.Invoke(coin);
        }
    }
}