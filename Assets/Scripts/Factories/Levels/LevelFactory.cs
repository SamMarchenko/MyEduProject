using Data;
using Factories.Levels;
using Levels;
using UnityEngine;

public class LevelFactory : ILevelFactory
{
    private readonly CoreLevelSettingsPreset _settingsPreset;
    private CoreLevel _currentLevel;

    public LevelFactory(CoreLevelSettingsPreset settingsPreset)
    {
        _settingsPreset = settingsPreset;
    }

    public CoreLevel CreateLevel()
    {
        if (_currentLevel != null)
            return _currentLevel;
        
        //todo: захардкожено всегда грузить первый кор уровень
        var level = _settingsPreset.LevelsSettings;
        _currentLevel = Object.Instantiate(level[0].LevelView);
        return _currentLevel;
    }
}