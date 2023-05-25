using System.Collections.Generic;
using ModestTree;
using Providers.JumpableUnits;
using Providers.MovableUnits;
using Services;
using Services.Input;
using Zenject;

namespace Controllers
{
    public class JumpController : ITickable, IInitInStart
    {
        private readonly IJumpableUnitsProvider _provider;
        private  List<IJumpable> _jumpables = new List<IJumpable>();


        public JumpController(IJumpableUnitsProvider provider)
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
                if(jumpable.CanJump())
                    jumpable.Jump();
            }
        }
        
        private void GetJumpableUnits()
        {
            _jumpables = _provider.GetJumpables();
            if (_jumpables.IsEmpty())
            {
                _provider.IHaveJumpables += GetJumpableUnits;
            }
        }
    }
}