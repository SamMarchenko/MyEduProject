using System;
using System.Collections.Generic;
using Controllers;
using ModestTree;
using Providers.Enemies;
using Providers.Player;
using Services;
using Units.Enemies;
using Units.Player;

namespace Providers.JumpableUnits
{
    public class JumpableUnitsProvider : IJumpableUnitsProvider, IInitInStart
    {
        private readonly IPlayerProvider _playerProvider;
        private readonly IEnemyProvider _enemyProvider;
        private List<IJumpable> _jumpables = new List<IJumpable>();
        
        public event Action IHaveJumpables;
        

        public JumpableUnitsProvider(IPlayerProvider playerProvider, IEnemyProvider enemyProvider)
        {
            _playerProvider = playerProvider;
            _enemyProvider = enemyProvider;
        }

        public List<IJumpable> GetJumpables()
        {
            if (_jumpables.IsEmpty())
                FindAllJumpables();
            return _jumpables;
        }

        public void Init()
        {
            FindAllJumpables();
        }
        
        private void FindAllJumpables()
        {
            var players = GetAllPlayers();
            if (players != null)
            {
                FindJumpablePlayers(players);
            }
            else
            {
                _playerProvider.ICreatePlayer += FindAllJumpables;
                return;
            }

            var enemies = GetAllEnemies();

            if (enemies != null)
            {
                FindJumpableEnemies(enemies);
            }
            else
            {
                _enemyProvider.ICreateEnemies += FindAllJumpables;
                return;
            }
            
            IHaveJumpables?.Invoke();
        }
        
        private List<IPlayer> GetAllPlayers()
        {
            List<IPlayer> players;
            _playerProvider.TryGetUnits(out players);
            return players;
        }
        
        private List<IEnemy> GetAllEnemies()
        {
            List<IEnemy> enemies;
            _enemyProvider.TryGetUnits(out enemies);
            return enemies;
        }
        
        private void FindJumpableEnemies(List<IEnemy> enemies)
        {
            foreach (var enemy in enemies)
            {
                if (enemy is IJumpable jumpableEnemy)
                {
                    _jumpables.Add(jumpableEnemy);
                }
            }
        }

        private void FindJumpablePlayers(List<IPlayer> players)
        {
            foreach (var player in players)
            {
                if (player is IJumpable jumpablePlayer)
                {
                    _jumpables.Add(jumpablePlayer);
                }
            }
        }
    }
}