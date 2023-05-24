using System;
using Levels;
using UnityEngine;

namespace Factories.Levels
{
    public interface ILevelFactory
    {
        CoreLevel CreateLevel();
    }
}