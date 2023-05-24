using Levels;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu]
    public class CoreLevelSettings : ScriptableObject
    {
        [SerializeField] private int _levelNumber;
        [SerializeField] private CoreLevel _levelView;

        public int LevelNumber => _levelNumber;
        public CoreLevel LevelView => _levelView;
    }
}