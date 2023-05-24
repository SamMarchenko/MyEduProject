using System.Collections.Generic;
using ModestTree;
using Providers;
using Providers.Enemies;
using Providers.Player;
using Units;
using Zenject;

namespace Controllers
{
    public class MoveController : ITickable
    {
        private readonly List<IUnitsProvider<IUnit>> _providers = new List<IUnitsProvider<IUnit>>();
        private readonly List<IMovable> _movables = new List<IMovable>();

        public MoveController(IPlayerProvider playerProvider, IEnemyProvider enemyProvider)
        {
            _providers.Add(playerProvider);
            _providers.Add(enemyProvider);
            GetMovablesUnits();
        }

        public void Tick()
        {
            foreach (var movable in _movables)
            {
                if (movable.CanMove())
                    movable.Move();
            }
        }

        private void GetMovablesUnits()
        {
            foreach (var provider in _providers)
            {
                var units = provider.GetUnits();
                if (!units.IsEmpty())
                {
                    FindMovableUnits(units);
                }
                else
                {
                    provider.IsHaveUnits += ProviderOnIsHaveUnits;
                }
            }
        }

        private void FindMovableUnits(List<IUnit> units)
        {
            foreach (var unit in units)
            {
                if (unit is IMovable movable)
                {
                    _movables.Add(movable);
                }
            }
        }

        private void ProviderOnIsHaveUnits(List<IUnit> units)
        {
            FindMovableUnits(units);
        }
    }
}