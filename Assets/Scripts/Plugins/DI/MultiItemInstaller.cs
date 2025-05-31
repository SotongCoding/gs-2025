using System;
using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using SotongStudio.VContainer;
using UnityEditor;
using UnityEngine;
using VContainer;

namespace SotongStudio.Plugins.DI
{
    public class MultiItemInstaller : ScriptInstaller
    {
        [ReadOnly]
        [SerializeField] private string _mainObjectScripting;
#if UNITY_EDITOR
        [SerializeField] private UnityEditor.MonoScript _mainObject;
#endif
        [SerializeField] private MonoBehaviour[] _components;

        public override void Install(IContainerBuilder builder)
        {
            if (string.IsNullOrEmpty(_mainObjectScripting) || _components.Length < 1)
            {
                return;
            }

            var itemBase = Type.GetType(_mainObjectScripting);
            var readonlyList = typeof(IReadOnlyList<>).MakeGenericType(itemBase);

            var listType = typeof(List<>).MakeGenericType(itemBase);
            IList listInstance = (IList)Activator.CreateInstance(listType);

            foreach (var component in _components)
            {
                var instance = Activator.CreateInstance(itemBase, new[] { component });
                listInstance.Add(instance);
            }

            builder.RegisterInstance(listInstance).As(readonlyList);

            builder.RegisterBuildCallback(resolver =>
            {
                foreach (var item in listInstance)
                {
                    resolver.Inject(item);
                }   
            });
        }

#if UNITY_EDITOR
        private void OnValidate()
        {
            if (EditorApplication.isPlayingOrWillChangePlaymode) { return; }

            if (_mainObject != null) VContainerDIInstallerUtils.RevalidateScript(_mainObject, ref _mainObjectScripting);
        }
#endif  
    }
}
