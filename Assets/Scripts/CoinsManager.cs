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
        void Spawn(int amount);
        List<Coin> GetLevelCoins();
        void Collect(Coin coin);
    }

    public class CoinsManager : ICoinsManager
    {
        public event Action OnAllCoinsCollected;
        
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

        public List<Coin> GetLevelCoins()
        {
            return new List<Coin>(_coins);
        }

        public void Collect(Coin coin)
        {
            _coins.Remove(coin);
            _coinsPool.Despawn(coin);
            
            if (_coins.IsEmpty())
            {
                OnAllCoinsCollected?.Invoke();
            }
        }
    }
}