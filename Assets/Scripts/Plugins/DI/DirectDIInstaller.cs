using System.Collections.Generic;
using NaughtyAttributes;
using SotongStudio.VContainer;
using UnityEditor;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace SotongStudio.Plugins.DI
{
    public class DirectDIInstaller : ScriptInstaller
    {
        [ReadOnly]
        [SerializeField] private string _mainObjectScripting;
        [ReadOnly]
        [SerializeField] private List<string> _otherObjectScriptings;
#if UNITY_EDITOR
        [SerializeField] private UnityEditor.MonoScript _mainObject;
        [SerializeField] private UnityEditor.MonoScript[] _otherObject;
#endif
        [SerializeField] private MonoBehaviour[] _viewComponents;

        public override void Install(IContainerBuilder builder)
        {
            if (string.IsNullOrEmpty(_mainObjectScripting))
            {
                return;
            }

            VContainerDIInstallerUtils.RegisterComponent(builder, _mainObjectScripting);
            foreach (var item in _otherObjectScriptings)
            {
                VContainerDIInstallerUtils.RegisterComponent(builder, item);
            }
            VContainerDIInstallerUtils.RegisterMonoBehaviourComponents(builder, _viewComponents);
        }

#if UNITY_EDITOR
        private void OnValidate()
        {
            if (EditorApplication.isPlayingOrWillChangePlaymode) { return; }

            if (_mainObject != null) VContainerDIInstallerUtils.RevalidateScript(_mainObject, ref _mainObjectScripting);

            if (_otherObject != null) VContainerDIInstallerUtils.RevalidateScripts(_otherObject, ref _otherObjectScriptings);

        }
#endif
    }
}
