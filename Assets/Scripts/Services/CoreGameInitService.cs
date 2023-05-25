using System.Collections.Generic;
using Data;
using Levels;
using Providers;
using Providers.Enemies;
using Providers.Player;
using Services.Input;
using Units.Enemies;
using Units.Player;
using Zenject;

namespace Services
{
    public class CoreGameInitService : IInitializable
    {
        //private readonly IPlayerProvider _playerProvider;
       // private readonly IEnemyProvider _enemyProvider;
        private readonly List<IUseLevelSettings> _levelSettingsUsers;
        private readonly List<IInitInStart> _initializeInStartList;

       // private readonly ILevelProvider _levelProvider;
        private readonly CoreLevelSettingsPreset _settingsPreset;
       // private List<IPlayer> _players;
        //private List<IEnemy> _enemies;
        private CoreLevelSettings _coreLevelSettings;
       // private CoreLevel _level;

        public CoreGameInitService(List<IUseLevelSettings> levelSettingsUsers, List<IInitInStart> initializeInStartList,
            CoreLevelSettingsPreset settingsPreset)
        {
            // _playerProvider = playerProvider;
            // _enemyProvider = enemyProvider;
            _levelSettingsUsers = levelSettingsUsers;
            _initializeInStartList = initializeInStartList;
           // _levelProvider = levelProvider;
            _settingsPreset = settingsPreset;
            //SetLevelSettings(_settingsPreset);
        }

        private void FindCurrentLevelSettings(CoreLevelSettingsPreset preset)
        {
            //todo: захардкожено всегда доставать 1 кор уровень
            _coreLevelSettings = preset.LevelsSettings.Find(o => o.LevelNumber == 1);
        }

        public void Initialize()
        {
            FindCurrentLevelSettings(_settingsPreset);
            SetLevelSettingsForAllUsers();
            InitAllInitializable();
        }

        private void SetLevelSettingsForAllUsers()
        {
            foreach (var user in _levelSettingsUsers)
            {
                user.SetLevelSettings(_coreLevelSettings);
            }
        }

        private void InitAllInitializable()
        {
            foreach (var entity in _initializeInStartList)
            {
                entity.Init();
            }


            //_playerProvider.SetPlayerSpawnPosition(_coreLevelSettings.LevelView.SpawnPositions.PlayerSpawnPos.position);
            // _enemyProvider.SetEnemiesSpawnPositions(_coreLevelSettings.LevelView.SpawnPositions.EnemiesSpawnPos);
            // _players = _playerProvider.GetUnits();
            // _enemies = _enemyProvider.GetUnits();
            // _level = _levelProvider.GetLevel();
        }

        private void Init()
        {
            // _playerProvider.SetPlayerSpawnPosition(_coreLevelSettings.LevelView.SpawnPositions.PlayerSpawnPos.position);
            // _enemyProvider.SetEnemiesSpawnPositions(_coreLevelSettings.LevelView.SpawnPositions.EnemiesSpawnPos);

            //_players = _playerProvider.GetUnits();
            // _enemies = _enemyProvider.GetUnits();
            //_level = _levelProvider.GetLevel();
        }
    }
}