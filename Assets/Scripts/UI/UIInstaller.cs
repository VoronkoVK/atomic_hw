using Zenject;

namespace DefaultNamespace
{
    public class UIInstaller : Installer<UIInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<LevelWidget>().AsSingle().NonLazy();
            Container.BindInterfacesTo<ScoreWidget>().AsSingle().NonLazy();
        }
    }
}