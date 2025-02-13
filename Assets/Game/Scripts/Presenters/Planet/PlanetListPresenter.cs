using System;
using System.Collections.Generic;
using Game.Views;
using Modules.Money;
using Modules.Planets;
using UnityEngine;
using Zenject;

namespace Game.Presenters
{
    public class PlanetListPresenter : IInitializable, IDisposable
    {
        private readonly Planet[] _planets; 
        private readonly PlanetListView _planetListView;
        private readonly PlanetPopupShower _popupShower;
        
        private List<PlanetPresenter> _presenters = new();

        public PlanetListPresenter(Planet[] planets, PlanetListView planetListView, PlanetPopupShower popupShower)
        {
            _planets = planets;
            _planetListView = planetListView;
            _popupShower = popupShower;
        }

        public void Initialize()
        {
            foreach (var planet in _planets)
            {
                var view = _planetListView.GetPlanetView(planet.Name);
                if (view == null)
                {
                    Debug.LogError($"Planet view for {planet.Name} not found.");
                }
                var presenter = new PlanetPresenter(planet, view, _popupShower);
                presenter.Initialize();
                _presenters.Add(presenter);
            }
        }

        public void Dispose()
        {
            foreach (var presenter in _presenters)
            {
                presenter.Dispose();
            }
        }
    }
}