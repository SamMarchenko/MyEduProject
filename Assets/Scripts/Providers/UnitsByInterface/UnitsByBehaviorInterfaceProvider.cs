using System;
using System.Collections.Generic;
using Controllers;
using Providers.Enemies;
using Providers.Player;
using Services;
using Services.Input;
using Units;
using Units.Enemies;
using Units.Player;

namespace Providers.UnitsByInterface
{
    public class UnitsByBehaviorInterfaceProvider : IInitInStart, IUnitsByBehaviorInterfaceProvider
    {
        private readonly IPlayerProvider _playerProvider;
        private readonly IEnemyProvider _enemyProvider;

        private List<IUnit> _units = new List<IUnit>();

        public event Action OnAllUnitsFound;


        public UnitsByBehaviorInterfaceProvider(IPlayerProvider playerProvider, IEnemyProvider enemyProvider)
        {
            _playerProvider = playerProvider;
            _enemyProvider = enemyProvider;
        }

        public void Init()
        {
            FindAllUnits();
        }

        public List<T> GetUnitsByInterface<T>()
        {
            if (typeof(T) == typeof(IMovable))
            {
                var movables = new List<T>();
                foreach (var unit in _units)
                {
                    if (unit is IMovable movable)
                    {
                        movables.Add((T) movable);
                    }
                }

                return movables;
            }

            if (typeof(T) == typeof(IJumpable))
            {
                var jumpables = new List<T>();
                foreach (var unit in _units)
                {
                    if (unit is IJumpable jumpable)
                    {
                        jumpables.Add((T) jumpable);
                    }
                }

                return jumpables;
            }

            if (typeof(T) == typeof(IInputListener))
            {
                var inputListeners = new List<T>();
                foreach (var unit in _units)
                {
                    if (unit is IInputListener inputListener)
                    {
                        inputListeners.Add((T) inputListener);
                    }
                }

                return inputListeners;
            }
            
            if (typeof(T) == typeof(IPatrolling))
            {
                var patrollings = new List<T>();
                foreach (var unit in _units)
                {
                    if (unit is IPatrolling patrolling)
                    {
                        patrollings.Add((T) patrolling);
                    }
                }

                return patrollings;
            }

            return null;
        }

        private void FindAllUnits()
        {
            var players = GetAllPlayers();
            if (players != null)
            {
                _units.AddRange(players);
            }
            else
            {
                _playerProvider.ICreatePlayer += FindAllUnits;
                return;
            }

            var enemies = GetAllEnemies();

            if (enemies != null)
            {
                _units.AddRange(enemies);
            }
            else
            {
                _enemyProvider.ICreateEnemies += FindAllUnits;
                return;
            }

            OnAllUnitsFound?.Invoke();
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