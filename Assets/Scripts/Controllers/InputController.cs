using System.Collections.Generic;
using ModestTree;
using Providers.InputListenerUnits;
using Services;
using Services.Input;
using Zenject;

namespace Controllers
{
    public class InputController : ITickable, IInitInStart
    {
        private List<IInputListener> _listeners = new List<IInputListener>();
        private readonly IInputListenerUnitsProvider _provider;
        private readonly IInputService _inputService;

        public InputController(IInputListenerUnitsProvider provider, IInputService inputService)
        {
            _provider = provider;
            _inputService = inputService;
        }

        public void Init()
        {
            GetInputListenersUnits();
        }

        public void Tick()
        {
            foreach (var listener in _listeners)
            {
                if (listener is IUnitControlInputListener l)
                {
                    l.IsJumpButtonClicked = _inputService.IsJumpButtonClicked;
                    l.MoveDirection = _inputService.MoveDirectionPressed;
                }
            }
        }
        
        private void GetInputListenersUnits()
        {
            _listeners = _provider.GetInputListeners();
            if (_listeners.IsEmpty())
            {
                _provider.IHaveInputListeners += GetInputListenersUnits;
            }
        }
    }
}