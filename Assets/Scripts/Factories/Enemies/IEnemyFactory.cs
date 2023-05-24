using System.Collections.Generic;
using Units.Enemies;
using UnityEngine;

namespace Factories.Enemies
{
    public interface IEnemyFactory<T> : IUnitsFactory<IEnemy>
    {
        List<IEnemy> CreateEnemies(List<Vector3> spawns);
        IEnemy CreateEnemy(T prefab);
    }
}