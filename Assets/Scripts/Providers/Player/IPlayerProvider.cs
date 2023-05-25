using System;
using Units.Player;

namespace Providers.Player
{
    public interface IPlayerProvider : IUnitsProvider<IPlayer>
    {
        event Action ICreatePlayer;
    }
}