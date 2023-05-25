using System;
using System.Collections.Generic;
using ModestTree;
using Providers.Enemies;
using Providers.Player;
using Services;
using Services.Input;
using Units.Enemies;
using Units.Player;

namespace Providers.InputListenerUnits
{
    public class InputListenerUnitsProvider : IInputListenerUnitsProvider, IInitInStart
    {
        private readonly IPlayerProvider _playerProvider;
        private readonly IEnemyProvider _enemyProvider;
        private List<IInputListener> _inputListeners = new List<IInputListener>();
        
        
        public event Action IHaveInputListeners;

        public InputListenerUnitsProvider(IPlayerProvider playerProvider, IEnemyProvider enemyProvider)
        {
            _playerProvider = playerProvider;
            _enemyProvider = enemyProvider;
        }
        
        public void Init()
        {
            FindAllInputListeners();
        }

        public List<IInputListener> GetInputListeners()
        {
            if (_inputListeners.IsEmpty())
                FindAllInputListeners();
            return _inputListeners;
        }

        private void FindAllInputListeners()
        {
            var players = GetAllPlayers();
            if (players != null)
            {
                FindInputListenerPlayers(players);
            }
            else
            {
                _playerProvider.ICreatePlayer += FindAllInputListeners;
                return;
            }
            var enemies = GetAllEnemies();

            if (enemies != null)
            {
                FindInputListenerEnemies(enemies);
            }
            else
            {
                _enemyProvider.ICreateEnemies += FindAllInputListeners;
                return;
            }
            
            IHaveInputListeners?.Invoke();
        }

        private void FindInputListenerEnemies(List<IEnemy> enemies)
        {
            foreach (var enemy in enemies)
            {
                if (enemy is IInputListener Enemy)
                {
                    _inputListeners.Add(Enemy);
                }
            }
        }

        private List<IEnemy> GetAllEnemies()
        {
            List<IEnemy> enemies;
            _enemyProvider.TryGetUnits(out enemies);
            return enemies;
        }

        private void FindInputListenerPlayers(List<IPlayer> players)
        {
            foreach (var player in players)
            {
                if (player is IInputListener Player)
                {
                    _inputListeners.Add(Player);
                }
            }
        }

        private List<IPlayer> GetAllPlayers()
        {
            List<IPlayer> players;
            _playerProvider.TryGetUnits(out players);
            return players;
        }
    }
}