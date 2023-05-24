using UnityEngine;

namespace Levels
{
    public class CoreLevel : MonoBehaviour
    {
        [SerializeField] private SpawnPositions _spawnPositions;
        public SpawnPositions SpawnPositions => _spawnPositions;
    }
}