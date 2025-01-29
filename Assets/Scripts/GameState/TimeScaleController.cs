using System;
using UnityEngine;
using Zenject;

namespace DefaultNamespace
{
    public class TimeScaleController : IInitializable, IDisposable
    {
        private readonly IGameCycle _gameCycle;

        public TimeScaleController(IGameCycle gameCycle)
        {
            _gameCycle = gameCycle;
        }

        public void Initialize()
        {
            _gameCycle.OnWin += OnGameOver;
            _gameCycle.OnLose += OnGameOver;
        }

        public void Dispose()
        {
            _gameCycle.OnWin -= OnGameOver;
            _gameCycle.OnLose -= OnGameOver;
        }

        private void OnGameOver()
        {
            Time.timeScale = 0;
        }
    }
}