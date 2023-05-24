using System.Collections.Generic;
using Data;
using Levels;
using Providers.Enemies;
using Providers.Player;
using Units.Enemies;
using Units.Player;
using Zenject;

namespace Services
{
    public class CoreGameInitService : IInitializable
    {
        private readonly IPlayerProvider _playerProvider;
        private readonly IEnemyProvider _enemyProvider;
        private readonly ILevelProvider _levelProvider;
        private readonly CoreLevelSettingsPreset _settingsPreset;
        private List<IPlayer> _players;
        private List<IEnemy> _enemies;
        private CoreLevelSettings _coreLevelSettings;
        private CoreLevel _level;

        public CoreGameInitService(IPlayerProvider playerProvider, IEnemyProvider enemyProvider,
            ILevelProvider levelProvider, CoreLevelSettingsPreset settingsPreset)
        {
            _playerProvider = playerProvider;
            _enemyProvider = enemyProvider;
            _levelProvider = levelProvider;
            _settingsPreset = settingsPreset;
        }

        private void SetLevelSettings(CoreLevelSettingsPreset preset)
        {
            //todo: захардкожено всегда доставать 1 кор уровень
            _coreLevelSettings = preset.LevelsSettings.Find(o => o.LevelNumber == 1);
        }

        public void Initialize()
        {
            SetLevelSettings(_settingsPreset);

            _playerProvider.SetPlayerSpawnPosition(_coreLevelSettings.LevelView.SpawnPositions.PlayerSpawnPos.position);
            _enemyProvider.SetEnemiesSpawnPositions(_coreLevelSettings.LevelView.SpawnPositions.EnemiesSpawnPos);

            _players = _playerProvider.GetUnits();
            _enemies = _enemyProvider.GetUnits();
            _level = _levelProvider.GetLevel();
        }
    }
}