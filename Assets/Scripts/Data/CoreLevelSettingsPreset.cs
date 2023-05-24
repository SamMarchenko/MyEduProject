using System.Collections.Generic;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu]
    public class CoreLevelSettingsPreset : ScriptableObject
    {
        [SerializeField] private List<CoreLevelSettings> levelsSettings;
   
        public List<CoreLevelSettings> LevelsSettings => levelsSettings;
    }
}