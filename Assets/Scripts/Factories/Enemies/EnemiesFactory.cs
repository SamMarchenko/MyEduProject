using System;
using System.Collections.Generic;
using Data;
using Providers;
using Units.Enemies;
using Units.Enemies.JumpingEnemy;
using Units.Enemies.MovingEnemy;
using Units.Enemies.PatrolEnemy;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Factories.Enemies
{
    public class EnemiesFactory : IEnemyFactory<IEnemy>, IUseLevelSettings
    {
        private readonly List<IEnemy> _prefabs;
        private Dictionary<EnemyType, Vector3> _levelSettingsEnemiesSpawnPositions = new Dictionary<EnemyType, Vector3>();
        private Dictionary<Object, Vector3> _enemyTypeSpawnPos = new Dictionary<Object, Vector3>();

        public EnemiesFactory(List<IEnemy> prefabs)
        {
            _prefabs = prefabs;
        }

        public void SetLevelSettings(CoreLevelSettings settings)
        {
            foreach (var enemyTypeSpawnPosPair in settings.LevelView.SpawnPositions.EnemiesSpawnPos)
            {
                _levelSettingsEnemiesSpawnPositions.Add(enemyTypeSpawnPosPair.Type, enemyTypeSpawnPosPair.SpawnPos.position);
            }
            SetEnemyTypeSpawnPosDictionary();
        }

        public List<IEnemy> CreateEnemies()
        {
            var createdEnemies = new List<IEnemy>();

            foreach (var keyValuePair in _enemyTypeSpawnPos)
            {
                var enemy = Object.Instantiate(keyValuePair.Key, keyValuePair.Value, Quaternion.identity);
                createdEnemies.Add(enemy as IEnemy);
            }
            return createdEnemies;
        }

        private void SetEnemyTypeSpawnPosDictionary()
        {
            foreach (var enemiesSpawnPosition in _levelSettingsEnemiesSpawnPositions)
            {
                Type enemyType = GetEnemyType(enemiesSpawnPosition.Key);
                var enemyPrefab = (Object)FindPrefab(enemyType);
                _enemyTypeSpawnPos.Add(enemyPrefab, enemiesSpawnPosition.Value);
            }
        }

        private IEnemy FindPrefab(Type enemyType)
        {
            foreach (var prefab in _prefabs)
            {
                if (prefab.GetType() == enemyType)
                {
                    return prefab;
                }
            }
            Debug.LogException(new Exception("Нет префаба с таким типом врагов"));
            return null;
        }

        private Type GetEnemyType(EnemyType type)
        {
            switch (type)
            {
                case EnemyType.MovingEnemy:
                    return typeof(MovingEnemy);
                case EnemyType.JumpingEnemy:
                    return typeof(JumpingEnemy);
                case EnemyType.PatrolEnemy:
                    return typeof(PatrolEnemy);
            }
            Debug.LogException(new Exception("Нет такого типа врагов"));
            return null;
        }
    }
}