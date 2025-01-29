using Zenject;

namespace DefaultNamespace
{
    public class GameStateInstaller : Installer<GameStateInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<IGameCycle>().To<GameCycle>().AsSingle();
            Container.BindInterfacesTo<GameOverUIController>().AsSingle().NonLazy();
            Container.BindInterfacesTo<TimeScaleController>().AsSingle().NonLazy();
        }
    }
}