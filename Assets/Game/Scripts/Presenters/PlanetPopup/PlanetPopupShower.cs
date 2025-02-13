using Game.Presenters.PlanetPopup;
using Game.Views;
using Modules.Planets;

namespace Game.Presenters
{
    public class PlanetPopupShower
    {
        private readonly PlanetPopupPresenter _presenter;
        private readonly PlanetPopupView _view;

        public PlanetPopupShower(PlanetPopupPresenter presenter, PlanetPopupView view)
        {
            _presenter = presenter;
            _view = view;
        }

        public void Show(Planet planet)
        {
            _presenter.ChangePlanet(planet);
            _view.Show();
        }
    }
}