﻿using Factories.Levels;
using Levels;

public class LevelProvider : ILevelProvider
{
    private CoreLevel _currentLevel;
    private readonly ILevelFactory _levelFactory;

    public LevelProvider(ILevelFactory levelFactory)
    {
        _levelFactory = levelFactory;
    }

    public CoreLevel GetLevel()
    {
        if (_currentLevel == null) 
            _currentLevel = _levelFactory.CreateLevel();

        return _currentLevel;
    }
}