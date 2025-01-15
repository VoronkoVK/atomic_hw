using System;
using TMPro;
using Zenject;

namespace DefaultNamespace.UI
{
    public class LevelWidget : IInitializable, IDisposable
    {
        private readonly TMP_Text _levelText;
        private readonly ILevelManager _levelManager;

        public LevelWidget(TMP_Text levelText, ILevelManager levelManager)
        {
            _levelText = levelText;
            _levelManager = levelManager;
        }

        public void Initialize()
        {
            _levelManager.OnLevelStarted += Updatelevel;
            Updatelevel(_levelManager.CurrentLevel, _levelManager.MaxLevel);
        }

        public void Dispose()
        {
            _levelManager.OnLevelStarted -= Updatelevel;
        }

        private void Updatelevel(int currentLevel, int maxLevel)
        {
            _levelText.text = $"Level: {currentLevel}/{maxLevel}";
        }
    }
}