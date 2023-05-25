using Data;
using Levels;
using Providers;
using UnityEngine;

namespace Factories.Levels
{
    public class LevelFactory : ILevelFactory, IUseLevelSettings
    {
        private CoreLevel _currentLevel;
        private CoreLevel _currentLevelPrefab;


        public void SetLevelSettings(CoreLevelSettings settings)
        {
            _currentLevelPrefab = settings.LevelView;
        }

        public CoreLevel CreateLevel()
        {
            if (_currentLevel != null)
                return _currentLevel;
        
            _currentLevel = Object.Instantiate(_currentLevelPrefab);
            return _currentLevel;
        }
    }
}