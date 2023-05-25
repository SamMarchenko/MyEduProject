using Factories.Levels;
using Levels;
using Services;
using Services.Input;

namespace Providers.CoreLevels
{
    public class LevelProvider : ILevelProvider, IInitInStart
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

        public void Init()
        {
            GetLevel();
        }
    }
}