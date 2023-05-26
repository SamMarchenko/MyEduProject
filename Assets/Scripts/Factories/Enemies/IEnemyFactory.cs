using System.Collections.Generic;
using Units.Enemies;

namespace Factories.Enemies
{
    public interface IEnemyFactory<T> : IUnitsFactory<IEnemy>
    {
        List<IEnemy> CreateEnemies();
    }
}