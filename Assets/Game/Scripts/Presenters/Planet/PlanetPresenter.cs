using System;
using Game.Views;
using Modules.Planets;
using Zenject;

namespace Game.Presenters
{
    public class PlanetPresenter : IInitializable, IDisposable
    {
        private Planet _planet;
        private PlanetView _view;
        private PlanetPopupShower _popupShower;

        public PlanetPresenter(Planet planet, PlanetView view, PlanetPopupShower popupShower)
        {
            _planet = planet;
            _view = view;
            _popupShower = popupShower;
        }

        public void Initialize()
        {
            _planet.OnUnlocked += OnPlanetUnlock;
            _planet.OnIncomeTimeChanged += OnPlanetIncomeChanged;
            _planet.OnIncomeReady += OnPlanetIncomeReady;
            
            _view.OnClick += OnPlanetClick;
            _view.OnHold += OnPlanetHold;

            UpdatePlanetView();
        }

        public void Dispose()
        {
            _planet.OnUnlocked -= OnPlanetUnlock;
            _planet.OnIncomeTimeChanged -= OnPlanetIncomeChanged;
            _planet.OnIncomeReady -= OnPlanetIncomeReady;
            
            _view.OnClick -= OnPlanetClick;
            _view.OnHold -= OnPlanetHold;
        }

        private void UpdatePlanetView()
        {
            _view.SetIcon(_planet.GetIcon(_planet.IsUnlocked));
            _view.ShowLock(!_planet.IsUnlocked);
            
            _view.ShowPrice(!_planet.IsUnlocked);
            _view.SetPrice(_planet.Price.ToString());
            
            _view.ShowIncome(_planet.IsUnlocked);
            _view.SetIncomeProgress(_planet.IncomeProgress);
            
            _view.ShowCoin(_planet.IsIncomeReady);
        }

        private void OnPlanetUnlock()
        {
            UpdatePlanetView();
        }

        private void OnPlanetIncomeChanged(float remainingTime)
        {
            var minutes = (int)(remainingTime / 60);
            var seconds = (int)(remainingTime % 60);
            _view.SetIncomeTime($"{minutes}m:{seconds}s");
            _view.SetIncomeProgress(_planet.IncomeProgress);
        }

        private void OnPlanetIncomeReady(bool isReady)
        {
            _view.ShowCoin(isReady);
            _view.ShowIncome(!isReady);
        }

        private void OnPlanetClick()
        {
            if (_planet.IsUnlocked)
            {
                GetMoney();
            }
            else
            {
                Unlock();
            }
        }

        private void OnPlanetHold()
        {
            _popupShower.Show(_planet);
        }

        private void GetMoney()
        {
            if (_planet.IsIncomeReady)
            {
                _planet.GatherIncome();
            }
        }

        private void Unlock()
        {
            if (_planet.CanUnlock)
            {
                _planet.Unlock();
            }
        }
    }
}