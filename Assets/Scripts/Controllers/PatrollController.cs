using System.Collections.Generic;
using Controllers;
using Providers.UnitsByInterface;
using Services;
using Zenject;

public class PatrollController : ITickable, IInitInStart, IBehaviourController
{
    private readonly IUnitsByBehaviorInterfaceProvider _provider;
    private List<IPatrolling> _patrollings = new List<IPatrolling>();


    public PatrollController(IUnitsByBehaviorInterfaceProvider provider)
    {
        _provider = provider;
    }

    public void Init()
    {
        GetUnits();
    }

    public void Tick()
    {
        foreach (var patrolling in _patrollings)
        {
            patrolling.Patrol();
        }
    }
        

    public void GetUnits()
    {
        _patrollings = _provider.GetUnitsByInterface<IPatrolling>();
        if (_patrollings == null)
        {
            _provider.OnAllUnitsFound += GetUnits;
        }
    }
}