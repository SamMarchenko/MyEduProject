using System.Collections.Generic;
using Providers.UnitsByInterface;
using Services;
using Zenject;

namespace Controllers
{
    public class JumpController : ITickable, IInitInStart, IBehaviourController
    {
        private readonly IUnitsByBehaviorInterfaceProvider _provider;
        private List<IJumpable> _jumpables = new List<IJumpable>();


        public JumpController(IUnitsByBehaviorInterfaceProvider provider)
        {
            _provider = provider;
        }

        public void Init()
        {
            GetUnits();
        }

        public void Tick()
        {
            foreach (var jumpable in _jumpables)
            {
               if (jumpable.CanJump())
                    jumpable.Jump();
            }
        }
        

        public void GetUnits()
        {
            _jumpables = _provider.GetUnitsByInterface<IJumpable>();
            if (_jumpables == null)
            {
                _provider.OnAllUnitsFound += GetUnits;
            }
        }
    }
}