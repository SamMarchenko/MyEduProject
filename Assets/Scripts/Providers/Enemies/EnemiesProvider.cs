using System;
using System.Collections.Generic;
using Data;
using Factories.Enemies;
using Levels;
using ModestTree;
using Services;
using Units.Enemies;
using UnityEngine;

namespace Providers.Enemies
{
    public class EnemiesProvider : IEnemyProvider, IInitInStart, IUseLevelSettings
    {
        private readonly EnemiesFactory _enemiesFactory;
        private readonly CoreLevelSettingsPreset _settingsPreset;
        private List<IEnemy> _enemies = new List<IEnemy>();
        private List<Vector3> _jumpingEnemiesSpawnPositions = new List<Vector3>();
        private List<Vector3> _movingEnemiesSpawnPositions = new List<Vector3>();
        private CoreLevelSettings _coreLevelSettings;
        public event Action ICreateEnemies;


        public EnemiesProvider(EnemiesFactory enemiesFactory, CoreLevelSettingsPreset settingsPreset)
        {
            _enemiesFactory = enemiesFactory;
            _settingsPreset = settingsPreset;
        }

        public void Init()
        {
            SetEnemiesSpawnPositions(_coreLevelSettings.LevelView.SpawnPositions.EnemiesSpawnPos);
            GetUnitsFromFactory();
        }

        public bool TryGetUnits(out List<IEnemy> units)
        {
            if (_enemies.IsEmpty())
            {
                units = null;
                return false;
            }


            units = _enemies;
            return true;
        }

        public void SetLevelSettings(CoreLevelSettings settings)
        {
            _coreLevelSettings = settings;
        }

        private void SetEnemiesSpawnPositions(SpawnPositions.SpawnEnemyType[] spawns)
        {
            foreach (var spawnEnemyType in spawns)
            {
                if (spawnEnemyType.Type == EnemyType.JumpingEnemy)
                {
                    _jumpingEnemiesSpawnPositions.Add(spawnEnemyType.SpawnPos.position);
                    continue;
                }

                if (spawnEnemyType.Type == EnemyType.MovingEnemy)
                {
                    _movingEnemiesSpawnPositions.Add(spawnEnemyType.SpawnPos.position);
                }
            }
        }

        private void GetUnitsFromFactory()
        {
            _enemies.AddRange(_enemiesFactory.CreateEnemies());

            ICreateEnemies?.Invoke();
        }
    }
}