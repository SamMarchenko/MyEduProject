using System;
using System.Collections.Generic;
using Factories;
using Factories.Enemies;
using Levels;
using ModestTree;
using Units.Enemies;
using UnityEngine;

namespace Providers.Enemies
{
    public class EnemiesProvider : IEnemyProvider
    {
        private readonly List<IUnitsFactory<IEnemy>> _enemyFactories;
        private List<IEnemy> _enemies = new List<IEnemy>();
        private List<Vector3> _jumpingEnemiesSpawnPositions = new List<Vector3>();
        private List<Vector3> _movingEnemiesSpawnPositions = new List<Vector3>();

        public event Action<List<IEnemy>> IsHaveUnits;

        public EnemiesProvider(List<IUnitsFactory<IEnemy>> enemyFactories)
        {
            _enemyFactories = enemyFactories;
        }

        public List<IEnemy> GetUnits()
        {
            if (!_enemies.IsEmpty())
                return _enemies;
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
            IsHaveUnits?.Invoke(_enemies);
            return _enemies;
        }

        public void SetEnemiesSpawnPositions(SpawnPositions.SpawnEnemyType[] spawns)
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
    }
}