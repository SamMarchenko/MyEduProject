using System.Collections.Generic;
using Units.Enemies;
using Units.Enemies.JumpingEnemy;
using UnityEngine;

namespace Factories.Enemies
{
    public class JumpingEnemyFactory : IEnemyFactory<JumpingEnemy>
    {
        private readonly JumpingEnemy _enemyPrefab;

        public JumpingEnemyFactory(JumpingEnemy enemyPrefab)
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

        public IEnemy CreateEnemy(JumpingEnemy prefab) =>
            Object.Instantiate(prefab);
    }
}