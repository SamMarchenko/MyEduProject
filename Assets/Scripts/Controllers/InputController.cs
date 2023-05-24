using System.Collections.Generic;
using Services.Input;
using Zenject;

namespace Controllers
{
    public class InputController : ITickable
    {
        private readonly List<IInputListener> _listeners;
        private readonly IInputService _inputService;

        public InputController(List<IInputListener> listeners, IInputService inputService)
        {
            _listeners = listeners;
            _inputService = inputService;
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
    }
}