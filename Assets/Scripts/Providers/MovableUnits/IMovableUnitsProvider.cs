using System;
using System.Collections.Generic;
using Controllers;

namespace Providers.MovableUnits
{
    public interface IMovableUnitsProvider
    {
        List<IMovable> GetMovables();
        event Action IHaveMovables;
    }
}