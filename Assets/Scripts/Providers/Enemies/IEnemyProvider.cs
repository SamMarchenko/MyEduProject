using System;
using Levels;
using Units.Enemies;

namespace Providers.Enemies
{
    public interface IEnemyProvider : IUnitsProvider<IEnemy>
    {
       // void SetEnemiesSpawnPositions(SpawnPositions.SpawnEnemyType[] spawns);
       event Action ICreateEnemies;
    }
}