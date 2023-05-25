using System;
using System.Collections.Generic;
using Data;
using Factories;
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
        private readonly List<IUnitsFactory<IEnemy>> _enemyFactories;
        private readonly CoreLevelSettingsPreset _settingsPreset;
        private List<IEnemy> _enemies = new List<IEnemy>();
        private List<Vector3> _jumpingEnemiesSpawnPositions = new List<Vector3>();
        private List<Vector3> _movingEnemiesSpawnPositions = new List<Vector3>();
        private CoreLevelSettings _coreLevelSettings;
        public event Action ICreateEnemies;


        public EnemiesProvider(List<IUnitsFactory<IEnemy>> enemyFactories, CoreLevelSettingsPreset settingsPreset)
        {
            _enemyFactories = enemyFactories;
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
            foreach (var enemyFactory in _enemyFactories)
            {
                if (enemyFactory is MovingEnemyFactory movingEnemyFactory)
                {
                    _enemies.AddRange(movingEnemyFactory.CreateEnemies(_movingEnemiesSpawnPositions));
                    continue;
                }

                if (enemyFactory is JumpingEnemyFactory jumpingEnemyFactory)
                {
                    _enemies.AddRange(jumpingEnemyFactory.CreateEnemies(_jumpingEnemiesSpawnPositions));
                }
            }
            
            ICreateEnemies?.Invoke();
        }
    }
}