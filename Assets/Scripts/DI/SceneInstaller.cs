using DefaultNamespace.Observers;
using DefaultNamespace.UI;
using Modules;
using SnakeGame;
using TMPro;
using UnityEngine;
using Zenject;

namespace DefaultNamespace.DI
{
    public class SceneInstaller : MonoInstaller
    {
        [SerializeField] private Snake _snake;
        [SerializeField] private Coin _coinPref;
        [Header("Level")] 
        [SerializeField] private LevelConfig _levelConfig;
        [Header("UI")] 
        [SerializeField] private TMP_Text _levelText;
        [SerializeField] private TMP_Text _scoreText;
        [SerializeField] private GameObject _winScreen;
        [SerializeField] private GameObject _loseScreen;
        [Header("World")] 
        [SerializeField] private Transform _worldTransform;


        public override void InstallBindings()
        {
            // Snake
            Container.BindInterfacesAndSelfTo<Snake>().FromInstance(_snake).AsSingle();
            Container.BindInterfacesTo<SnakeController>().AsSingle().NonLazy();

            // Systems
            Container.Bind<IWorldBounds>().To<WorldBounds>().FromComponentInHierarchy().AsSingle();

            Container.BindMemoryPool<Coin, CoinsPool>()
                .WithInitialSize(_levelConfig.CoinsOnLevel)
                .WithMaxSize(_levelConfig.CoinsOnLevel)
                .ExpandByOneAtATime()
                .FromComponentInNewPrefab(_coinPref)
                .WithGameObjectName("Coin")
                .UnderTransform(_worldTransform)
                .AsSingle();

            // Managers
            Container.Bind<IGameStateManager>().To<GameStateManager>().AsSingle().WithArguments(_winScreen, _loseScreen);
            Container.Bind<ICoinsManager>().To<CoinsManager>().AsSingle();
            Container.BindInterfacesTo<LevelManager>().AsSingle().WithArguments(_levelConfig);
            Container.BindInterfacesTo<ScoreManager>().AsSingle();

            // Observers
            Container.BindInterfacesTo<CollectCoinObserver>().AsSingle().NonLazy();
            Container.BindInterfacesTo<DeathObserver>().AsSingle().NonLazy();

            // UI
            Container.BindInterfacesTo<LevelWidget>().AsSingle().WithArguments(_levelText).NonLazy();
            Container.BindInterfacesTo<ScoreWidget>().AsSingle().WithArguments(_scoreText).NonLazy();
        }
    }
}