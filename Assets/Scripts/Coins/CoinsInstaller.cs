using Zenject;

namespace DefaultNamespace
{
    public class CoinsInstaller : Installer<CoinsInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<ICoinsManager>().To<CoinsManager>().AsSingle();

        }
    }
}