using Modules;
using SnakeGame;
using UnityEngine;
using Zenject;

namespace DefaultNamespace
{
    public class SceneInstaller : MonoInstaller
    {
        [SerializeField] private Modules.Snake _snake;
        [SerializeField] private GameUI _gameUI;
        [SerializeField] private Coin _coinPref;
        [Header("Level")] 
        [SerializeField] private LevelConfig _levelConfig;
        [Header("World")] 
        [SerializeField] private Transform _worldTransform;


        public override void InstallBindings()
        {
            // Modules
            Container.Bind<IWorldBounds>().To<WorldBounds>().FromComponentInHierarchy().AsSingle();
            Container.Bind<ISnake>().To<Modules.Snake>().FromInstance(_snake).AsSingle();
            Container.Bind<IScore>().To<Score>().AsSingle();
            Container.Bind<IDifficulty>().To<Difficulty>().AsSingle().WithArguments(_levelConfig.MaxLevel);
            Container.Bind<IGameUI>().To<GameUI>().FromInstance(_gameUI).AsSingle();
            
            Container.BindMemoryPool<Coin, CoinsPool>()
                .WithInitialSize(_levelConfig.CoinsOnLevel)
                .WithMaxSize(_levelConfig.CoinsOnLevel)
                .ExpandByOneAtATime()
                .FromComponentInNewPrefab(_coinPref)
                .WithGameObjectName("Coin")
                .UnderTransform(_worldTransform)
                .AsSingle();

            Container.Bind<LevelConfig>().FromInstance(_levelConfig).AsSingle();
            
            SnakeInstaller.Install(Container);
            GameStateInstaller.Install(Container);
            UIInstaller.Install(Container);
            CoinsInstaller.Install(Container);
            LevelInstaller.Install(Container);
        }
    }
}