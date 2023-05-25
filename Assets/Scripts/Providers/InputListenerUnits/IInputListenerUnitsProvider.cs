using System;
using System.Collections.Generic;
using Services.Input;

namespace Providers.InputListenerUnits
{
    public interface IInputListenerUnitsProvider
    {
        List<IInputListener> GetInputListeners();
        event Action IHaveInputListeners;
    }
}