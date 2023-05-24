using System.Collections.Generic;
using Units.Enemies;
using Units.Enemies.MovingEnemy;
using UnityEngine;

namespace Factories.Enemies
{
    public class MovingEnemyFactory : IEnemyFactory<MovingEnemy>
    {
        private readonly MovingEnemy _enemyPrefab;

        public MovingEnemyFactory(MovingEnemy enemyPrefab)
        {
            _enemyPrefab = enemyPrefab;
        }
        
        public List<IEnemy> CreateEnemies(List<Vector3> spawns)
        {
            var createdEnemies = new List<IEnemy>();
            foreach (var spawn in spawns)
            {
                createdEnemies.Add(Object.Instantiate(_enemyPrefab, spawn, Quaternion.identity));
            }
            return createdEnemies;
        }

        public IEnemy CreateEnemy(MovingEnemy prefab) =>
            Object.Instantiate(prefab);
    }
}