using System;
using Levels;
using Units.Enemies;

namespace Providers.Enemies
{
    public interface IEnemyProvider : IUnitsProvider<IEnemy>
    {
        event Action ICreateEnemies;
    }
}