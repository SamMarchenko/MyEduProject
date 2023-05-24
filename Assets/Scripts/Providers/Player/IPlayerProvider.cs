using Units;
using Units.Player;
using UnityEngine;

namespace Providers.Player
{
    public interface IPlayerProvider : IUnitsProvider<IPlayer>
    {
        void SetPlayerSpawnPosition(Vector3 spawn);
    }
}