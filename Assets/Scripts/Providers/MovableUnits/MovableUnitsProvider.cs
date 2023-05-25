using System;
using System.Collections.Generic;
using Controllers;
using ModestTree;
using Providers.Enemies;
using Providers.Player;
using Services;
using Services.Input;
using Units.Enemies;
using Units.Player;

namespace Providers.MovableUnits
{
    public class MovableUnitsProvider : IMovableUnitsProvider, IInitInStart
    {
        private readonly IPlayerProvider _playerProvider;
        private readonly IEnemyProvider _enemyProvider;
        private List<IMovable> _movables = new List<IMovable>();

        public event Action IHaveMovables;

        public MovableUnitsProvider(IPlayerProvider playerProvider, IEnemyProvider enemyProvider)
        {
            _playerProvider = playerProvider;
            _enemyProvider = enemyProvider;
        }

        public void Init()
        {
            FindAllMovables();
        }

        public List<IMovable> GetMovables()
        {
            if (_movables.IsEmpty())
                FindAllMovables();
            return _movables;
        }

        private void FindAllMovables()
        {
            var players = GetAllPlayers();
            if (players != null)
            {
                FindMovablePlayers(players);
            }
            else
            {
                _playerProvider.ICreatePlayer += FindAllMovables;
                return;
            }

            var enemies = GetAllEnemies();

            if (enemies != null)
            {
                FindMovableEnemies(enemies);
            }
            else
            {
                _enemyProvider.ICreateEnemies += FindAllMovables;
                return;
            }
            
            IHaveMovables?.Invoke();
        }

        private void FindMovableEnemies(List<IEnemy> enemies)
        {
            foreach (var enemy in enemies)
            {
                if (enemy is IMovable movableEnemy)
                {
                    _movables.Add(movableEnemy);
                }
            }
        }

        private void FindMovablePlayers(List<IPlayer> players)
        {
            foreach (var player in players)
            {
                if (player is IMovable movablePlayer)
                {
                    _movables.Add(movablePlayer);
                }
            }
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
    }
}