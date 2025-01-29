using Zenject;

namespace DefaultNamespace
{
    public class LevelInstaller : Installer<LevelInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<AddScoreController>().AsSingle().NonLazy();
            Container.BindInterfacesTo<ChangeLevelController>().AsSingle().NonLazy();
            Container.BindInterfacesTo<SpawnCoinsController>().AsSingle().NonLazy();
        }
    }
}