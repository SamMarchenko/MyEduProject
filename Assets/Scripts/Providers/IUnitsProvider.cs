using System.Collections.Generic;

namespace Providers
{
    public interface IUnitsProvider<T>
    {
        bool TryGetUnits(out List<T> units);
    }
}