﻿using System.Collections.Generic;
using Providers.UnitsByInterface;
using Services;
using Services.Input;
using Zenject;

namespace Controllers
{
    public class InputController : ITickable, IInitInStart
    {
        private List<IInputListener> _listeners = new List<IInputListener>();
        private readonly IUnitsByBehaviorInterfaceProvider _provider;
        private readonly IInputService _inputService;

        public InputController(
            IUnitsByBehaviorInterfaceProvider provider,
            IInputService inputService)
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
            if (_listeners == null)
                return;
            
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
            _listeners = _provider.GetUnitsByInterface<IInputListener>();
            if (_listeners == null)
            {
                _provider.OnAllUnitsFound += GetInputListenersUnits;
            }
        }
    }
}