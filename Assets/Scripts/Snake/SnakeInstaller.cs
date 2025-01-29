using Zenject;

namespace DefaultNamespace
{
    public class SnakeInstaller : Installer<SnakeInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<SnakeInputController>().AsSingle().NonLazy();
            Container.BindInterfacesTo<CollisionCoinObserver>().AsSingle().NonLazy();
            Container.BindInterfacesTo<DeathObserver>().AsSingle().NonLazy();
            Container.BindInterfacesTo<SnakeSpeedController>().AsSingle().NonLazy();
            Container.BindInterfacesTo<SnakeSizeController>().AsSingle().NonLazy();
        }
    }
}