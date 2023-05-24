using System;
using System.Collections.Generic;
using UnityEngine;

namespace Providers
{
    public interface IUnitsProvider<T>
    {
        List<T> GetUnits();
        event Action<List<T>> IsHaveUnits;
    }
}