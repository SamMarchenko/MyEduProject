using Units.Player;
using UnityEngine;

namespace Factories.Player
{
    public interface IPlayerFactory : IUnitsFactory<IPlayer>
    {
        IPlayer CreatePlayer(Vector3 spawn);
    }
}