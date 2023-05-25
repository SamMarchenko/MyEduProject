using System;
using System.Collections.Generic;
using Controllers;

namespace Providers.JumpableUnits
{
    public interface IJumpableUnitsProvider
    {
        List<IJumpable> GetJumpables();
        event Action IHaveJumpables;
    }
}