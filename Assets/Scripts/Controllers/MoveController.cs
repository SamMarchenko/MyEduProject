using System.Collections.Generic;
using Providers.UnitsByInterface;
using Services;
using Zenject;

namespace Controllers
{
    public class MoveController : ITickable, IInitInStart, IBehaviourController
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
            GetUnits();
        }

        public void Tick()
        {
            foreach (var movable in _movables)
            {
                if (movable.CanMove())
                    movable.Move();
            }
        }
        

        public void GetUnits()
        {
            _movables = _provider.GetUnitsByInterface<IMovable>();
            if (_movables == null)
            {
                _provider.OnAllUnitsFound += GetUnits;
            }
        }
    }
}