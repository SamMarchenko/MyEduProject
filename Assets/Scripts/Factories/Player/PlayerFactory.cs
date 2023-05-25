using Units.Player;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Factories.Player
{
    public class PlayerFactory : IPlayerFactory
    {
        private readonly Units.Player.Player _playerPrefab;

        public PlayerFactory(Units.Player.Player playerPrefab)
        {
            _playerPrefab = playerPrefab;
        }

        public IPlayer CreatePlayer(Vector3 spawn)
        {
            var player = Object.Instantiate(_playerPrefab, spawn, Quaternion.identity);
            return player;
        }
    }
}