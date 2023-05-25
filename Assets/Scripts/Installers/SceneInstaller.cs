using Controllers;
using Factories.Enemies;
using Factories.Levels;
using Factories.Player;
using Providers;
using Providers.CoreLevels;
using Providers.Enemies;
using Providers.InputListenerUnits;
using Providers.JumpableUnits;
using Providers.MovableUnits;
using Providers.Player;
using Services;
using Services.Input;
using Units;
using Units.Enemies.JumpingEnemy;
using Units.Enemies.MovingEnemy;
using Units.Player;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class SceneInstaller : MonoInstaller
    {
        [SerializeField] private Player _playerPrefab;
        [SerializeField] private MovingEnemy _movingEnemyPrefab;
        [SerializeField] private JumpingEnemy _jumpingEnemyPrefab;
        
        public override void InstallBindings()
        {
            
            BindPlayer();
            BindEnemies();
            BindFactories();
            BindProviders();

            
            
            Container.BindInterfacesAndSelfTo<InputController>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<KeyBoardInputService>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<MoveController>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<JumpController>().AsSingle().NonLazy();
            
            Container.BindInterfacesAndSelfTo<CoreGameInitService>().AsSingle().NonLazy();

        }

        private void BindProviders()
        {
            Container.BindInterfacesAndSelfTo<PlayerProvider>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<EnemiesProvider>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<LevelProvider>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<MovableUnitsProvider>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<JumpableUnitsProvider>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<InputListenerUnitsProvider>().AsSingle().NonLazy();
        }

        private void BindFactories()
        {
            Container.BindInterfacesAndSelfTo<PlayerFactory>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<MovingEnemyFactory>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<JumpingEnemyFactory>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<LevelFactory>().AsSingle().NonLazy();
        }

        private void BindEnemies()
        {
            Container.BindInterfacesAndSelfTo<MovingEnemy>().FromInstance(_movingEnemyPrefab);
            Container.BindInterfacesAndSelfTo<JumpingEnemy>().FromInstance(_jumpingEnemyPrefab);
        }

        private void BindPlayer()
        {
            Container.BindInterfacesAndSelfTo<Player>().FromInstance(_playerPrefab);
        }
    }
}