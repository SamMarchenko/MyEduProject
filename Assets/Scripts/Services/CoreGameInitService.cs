using System.Collections.Generic;
using Data;
using Providers;
using Zenject;

namespace Services
{
    public class CoreGameInitService : IInitializable
    {
        private readonly List<IUseLevelSettings> _levelSettingsUsers;
        private readonly List<IInitInStart> _initializeInStartList;
        private readonly CoreLevelSettingsPreset _settingsPreset;
        private CoreLevelSettings _coreLevelSettings;

        public CoreGameInitService(List<IUseLevelSettings> levelSettingsUsers, List<IInitInStart> initializeInStartList,
            CoreLevelSettingsPreset settingsPreset)
        {
            _levelSettingsUsers = levelSettingsUsers;
            _initializeInStartList = initializeInStartList;
            _settingsPreset = settingsPreset;
        }

        public void Initialize()
        {
            FindCurrentLevelSettings(_settingsPreset);
            SetLevelSettingsForAllUsers();
            InitAllInitializable();
        }

        private void FindCurrentLevelSettings(CoreLevelSettingsPreset preset)
        {
            //todo: захардкожено всегда доставать 1 кор уровень
            _coreLevelSettings = preset.LevelsSettings.Find(o => o.LevelNumber == 1);
        }

        private void SetLevelSettingsForAllUsers()
        {
            foreach (var user in _levelSettingsUsers)
            {
                user.SetLevelSettings(_coreLevelSettings);
            }
        }

        private void InitAllInitializable()
        {
            foreach (var entity in _initializeInStartList)
            {
                entity.Init();
            }
            
        }
    }
}