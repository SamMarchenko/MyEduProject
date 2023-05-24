using System;
using System.Collections.Generic;
using Factories.Player;
using ModestTree;
using Units.Player;
using UnityEngine;

namespace Providers.Player
{
    public class PlayerProvider : IPlayerProvider
    {
        private readonly IPlayerFactory _playerFactory;
        private List<IPlayer> _players = new List<IPlayer>();
        private Vector3 _playerSpawnPos;

        public event Action<List<IPlayer>> IsHaveUnits;

        public PlayerProvider(IPlayerFactory playerFactory)
        {
            _playerFactory = playerFactory;
        }


        public List<IPlayer> GetUnits()
        {
            if (!_players.IsEmpty())
                return _players;
            var player = _playerFactory.CreatePlayer(_playerSpawnPos);
            _players.Add(player);
            IsHaveUnits?.Invoke(_players);
            return _players;
        }

        public void SetPlayerSpawnPosition(Vector3 spawn)
        {
            _playerSpawnPos = spawn;
        }
    }
}