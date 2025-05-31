using System;
using UnityEngine;
using VContainer;
using VContainer.Unity;

#nullable enable

namespace SotongStudio.Plugins.DI
{
    public abstract class ScriptInstaller : MonoBehaviour, IInstaller
    {
        protected LifetimeScope? AsChildParent;
        public abstract void Install(IContainerBuilder builder);

        public void CreateChild(LifetimeScope parentScope)
        {
            AsChildParent = parentScope;
            var currentParent = parentScope.CreateChild((builder) =>
            {
                Install(builder);
            });
            PostCreateChildProcess(currentParent);
        }

        protected virtual void PostCreateChildProcess(LifetimeScope currentParent)
        {

        }
    }
}
