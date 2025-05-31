using System;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace SotongStudio.Plugins.DI
{
    public class SubScope : ScriptInstaller
    {
        [SerializeField] private ScriptInstaller[] _additionalInstaller;
        [SerializeField] private ScriptInstaller[] _childInstaller;
        public override void Install(IContainerBuilder builder)
        {
            foreach (var installer in _additionalInstaller)
            {
                installer.Install(builder);
            }
        }

        protected override void PostCreateChildProcess(LifetimeScope currentParent)
        {
            foreach (var installer in _childInstaller)
            {
                currentParent.CreateChild(installer);
            }

        }
    }
}