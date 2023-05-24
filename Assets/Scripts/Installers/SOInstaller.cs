using Data;
using UnityEngine;
using Zenject;

namespace Installers
{
    [CreateAssetMenu]
    public class SOInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private CoreLevelSettingsPreset coreLevelsPreset;

        public override void InstallBindings()
        {
            Container.BindInstance(coreLevelsPreset);
        }
    }
}