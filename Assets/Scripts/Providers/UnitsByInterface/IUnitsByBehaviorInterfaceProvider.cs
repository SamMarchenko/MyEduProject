using System;
using System.Collections.Generic;

namespace Providers.UnitsByInterface
{
    public interface IUnitsByBehaviorInterfaceProvider
    {
        List<T> GetUnitsByInterface<T>();
        public event Action OnAllUnitsFound;
    }
}