using UnityEngine;
using Zenject;

namespace Game.Views
{
    public sealed class ViewsInstaller : MonoInstaller
    {
        [SerializeField] private PlanetListView _planetListView;
        [SerializeField] private MoneyView _moneyView;
        

        public override void InstallBindings()
        {
            //TODO:
            Container
                .BindInterfacesAndSelfTo<PlanetListView>()
                .FromInstance(_planetListView)
                .AsSingle()
                .NonLazy();
            
            Container
                .BindInterfacesAndSelfTo<MoneyView>()
                .FromInstance(_moneyView)
                .AsSingle()
                .NonLazy();
            
            Container
                .Bind<PlanetPopupView>()
                .FromComponentInHierarchy()
                .AsSingle()
                .NonLazy();
            
        }
    }
}