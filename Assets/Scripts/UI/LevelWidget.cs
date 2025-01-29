﻿using System;
using Modules;
using SnakeGame;
using TMPro;
using UnityEngine;
using Zenject;

namespace DefaultNamespace
{
    public class LevelWidget : IInitializable, IDisposable
    {
        private readonly IDifficulty _difficulty;
        private readonly IGameUI _ui;


        public LevelWidget(IDifficulty difficulty, IGameUI ui)
        {
            _difficulty = difficulty;
            _ui = ui;
        }

        public void Initialize()
        {
            _difficulty.OnStateChanged += OnDifficultyChanged;
            OnDifficultyChanged();
        }

        public void Dispose()
        {
            _difficulty.OnStateChanged -= OnDifficultyChanged;
        }

        private void OnDifficultyChanged()
        {
            _ui.SetDifficulty(_difficulty.Current, _difficulty.Max);
        }
    }
}