using System;
using Modules.Money;
using Modules.Planets;
using UnityEngine;
using Zenject;

namespace Game.Presenters.PlanetPopup
{
    public class PlanetPopupPresenter : IInitializable, IDisposable
    {
        public event Action OnPlanetChanged;
        public event Action OnUnlocked;
        public event Action OnUpgraded;
        public event Action OnPopulationChanged;
        public event Action OnIncomeChanged;
        public event Action OnMoneyChanged;

        public Sprite Sprite => _planet?.GetIcon(_planet.IsUnlocked);
        public string Title => _planet != null ? _planet.Name : string.Empty;
        public string Population => _planet != null ? $"Population: {_planet.Population}" : string.Empty;
        public string Level => _planet != null ? $"Level: {_planet.Level}/{_planet.MaxLevel}" : string.Empty;
        public bool IsMaxLevel => _planet != null && _planet.IsMaxLevel;
        public string Income => _planet != null ? $"Income: {_planet.MinuteIncome} / sec" : string.Empty;
        public string Price => _planet != null ? _planet.Price.ToString() : string.Empty;
        public bool CanUnlockOrUpgrade => _planet != null && _planet.CanUnlockOrUpgrade;
        public string UpgradeText => GetUpgradeTitle();
        
        private readonly IMoneyStorage _moneyStorage;
        private Planet _planet;

        public PlanetPopupPresenter(IMoneyStorage moneyStorage)
        {
            _moneyStorage = moneyStorage;
        }
        
        public void Initialize()
        {
            _moneyStorage.OnMoneyChanged += OnMoneyStorageChanged;
        }

        public void Dispose()
        {
            _moneyStorage.OnMoneyChanged -= OnMoneyStorageChanged;
        }

        public void ChangePlanet(Planet planet)
        {
            UnsubscribeFromPlanetEvents();
            _planet = planet;
            SubscribeToPlanetEvents();
            OnPlanetChanged?.Invoke();
        }

        public void UnlockOrUpgrade()
        {
            if (_planet != null && _planet.CanUnlockOrUpgrade)
            {
                _planet.UnlockOrUpgrade();
            }
        }

        private void SubscribeToPlanetEvents()
        {
            if (_planet == null)
            {
                return;
            }

            _planet.OnUnlocked += OnPlanetUnlocked;
            _planet.OnUpgraded += OnPlanetUpgraded;
            _planet.OnIncomeChanged += OnPlanetIncomeChanged;
            _planet.OnPopulationChanged += OnPlanetPopulationChanged;
        }

        private void UnsubscribeFromPlanetEvents()
        {
            if (_planet == null)
            {
                return;
            }
            
            _planet.OnUnlocked -= OnPlanetUnlocked;
            _planet.OnUpgraded -= OnPlanetUpgraded;
            _planet.OnIncomeChanged -= OnPlanetIncomeChanged;
            _planet.OnPopulationChanged -= OnPlanetPopulationChanged;
        }

        private void OnMoneyStorageChanged(int a, int b)
        {
            OnMoneyChanged?.Invoke();
        }

        private void OnPlanetUnlocked()
        {
            OnUnlocked?.Invoke();
        }

        private void OnPlanetUpgraded(int lvl)
        {
            OnUpgraded?.Invoke();
        }

        private void OnPlanetIncomeChanged(int income)
        {
            OnIncomeChanged?.Invoke();
        }

        private void OnPlanetPopulationChanged(int population)
        {
            OnPopulationChanged?.Invoke();
        }

        private string GetUpgradeTitle()
        {
            if (_planet == null)
            {
                return string.Empty;
            }

            if (_planet.IsMaxLevel)
            {
                return "MAX LEVEL";
            }
            
            return _planet.IsUnlocked ? "Upgrade" : "Unlock";
        }
    }
}