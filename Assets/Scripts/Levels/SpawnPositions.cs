using System;
using Units.Enemies;
using UnityEngine;

namespace Levels
{
    public class SpawnPositions : MonoBehaviour
    {
        [SerializeField] private Transform _playerSpawnPos;
        [SerializeField] private SpawnEnemyType[] _enemiesSpawnPos;

        public Transform PlayerSpawnPos => _playerSpawnPos;
        public SpawnEnemyType[] EnemiesSpawnPos => _enemiesSpawnPos;
    
        [Serializable]
        public struct SpawnEnemyType
        {
            public EnemyType Type;
            public Transform SpawnPos;
        }
    }
}