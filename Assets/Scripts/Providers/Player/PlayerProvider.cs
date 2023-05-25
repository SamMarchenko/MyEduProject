using System;
using System.Collections.Generic;
using Data;
using Factories.Player;
using ModestTree;
using Services;
using Units.Player;
using UnityEngine;

namespace Providers.Player
{
    public class PlayerProvider : IPlayerProvider, IInitInStart, IUseLevelSettings
    {
        private readonly IPlayerFactory _playerFactory;
        private readonly CoreLevelSettingsPreset _settingsPreset;
        private List<IPlayer> _players = new List<IPlayer>();
        private Vector3 _playerSpawnPos;
        private CoreLevelSettings _coreLevelSettings;
        public event Action ICreatePlayer;
        
        public PlayerProvider(IPlayerFactory playerFactory, CoreLevelSettingsPreset settingsPreset)
        {
            _playerFactory = playerFactory;
            _settingsPreset = settingsPreset;
        }


        public void Init()
        {
            _playerSpawnPos = _coreLevelSettings.LevelView.SpawnPositions.PlayerSpawnPos.position;
            GetUnitsFromFactory();
        }

        public void SetLevelSettings(CoreLevelSettings settings)
        {
            _coreLevelSettings = settings;
        }

        public bool TryGetUnits(out List<IPlayer> units)
        {
            if (_players.IsEmpty())
            {
                units = null;
                return false;
            }

            units = _players;
            return true;
        }


        private void GetUnitsFromFactory()
        {
            var player = _playerFactory.CreatePlayer(_playerSpawnPos);
            _players.Add(player);
            ICreatePlayer?.Invoke();
        }
    }
}