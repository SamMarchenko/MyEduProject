using System.Collections.Generic;
using Providers.UnitsByInterface;
using Services;
using Zenject;

namespace Controllers
{
    public class JumpController : ITickable, IInitInStart
    {
        private readonly IUnitsByBehaviorInterfaceProvider _provider;
        private List<IJumpable> _jumpables = new List<IJumpable>();


        public JumpController(IUnitsByBehaviorInterfaceProvider provider)
        {
            _provider = provider;
        }

        public void Init()
        {
            GetJumpableUnits();
        }

        public void Tick()
        {
            foreach (var jumpable in _jumpables)
            {
                if (jumpable.CanJump())
                    jumpable.Jump();
            }
        }

        private void GetJumpableUnits()
        {
            _jumpables = _provider.GetUnitsByInterface<IJumpable>();
            if (_jumpables == null)
            {
                _provider.OnAllUnitsFound += GetJumpableUnits;
            }
        }
    }
}