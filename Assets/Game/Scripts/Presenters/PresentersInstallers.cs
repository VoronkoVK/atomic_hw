using Game.Presenters.PlanetPopup;
using UnityEngine;
using Zenject;

namespace Game.Presenters
{
    [CreateAssetMenu(
        fileName = "PresentersInstallers",
        menuName = "Zenject/New PresentersInstallers"
    )]
    public sealed class PresentersInstallers : ScriptableObjectInstaller
    {
        public override void InstallBindings()
        {
            //TODO:
            
            Container
                .BindInterfacesAndSelfTo<PlanetPopupPresenter>()
                .AsSingle();
            
            Container
                .BindInterfacesAndSelfTo<PlanetPopupShower>()
                .AsSingle();

            Container
                .BindInterfacesAndSelfTo<PlanetListPresenter>()
                .AsSingle()
                .NonLazy();

            Container
                .BindInterfacesAndSelfTo<MoneyPresenter>()
                .AsSingle()
                .NonLazy();

            

            
        }
    }
}