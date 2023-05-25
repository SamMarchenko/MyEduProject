using System.Collections.Generic;
using ModestTree;
using Providers.MovableUnits;
using Services;
using Services.Input;
using Zenject;

namespace Controllers
{
    public class MoveController : ITickable, IInitInStart
    {
        private readonly IMovableUnitsProvider _provider;

        private List<IMovable> _movables = new List<IMovable>();

        public MoveController(IMovableUnitsProvider provider)
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
            _movables = _provider.GetMovables();
            if (_movables.IsEmpty())
            {
                _provider.IHaveMovables += GetMovablesUnits;
            }
        }
    }
}