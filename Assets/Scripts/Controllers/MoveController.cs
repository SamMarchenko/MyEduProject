using System.Collections.Generic;
using Providers.UnitsByInterface;
using Services;
using Zenject;

namespace Controllers
{
    public class MoveController : ITickable, IInitInStart
    {
        private readonly IUnitsByBehaviorInterfaceProvider _provider;

        private List<IMovable> _movables = new List<IMovable>();

        public MoveController(
            IUnitsByBehaviorInterfaceProvider provider)
        {
            _provider = provider;
        }

        public void Init()
        {
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
            _movables = _provider.GetUnitsByInterface<IMovable>();
            if (_movables == null)
            {
                _provider.OnAllUnitsFound += GetMovablesUnits;
            }
        }
    }
}