using VContainer.Unity;
using UnityEngine;
using VContainer;
using System.Collections.Generic;

namespace SotongStudio.VContainer.Test
{
    public class TestingScope 
    {
        [SerializeField]
        private VContainerInstallerObject[] InstallerObejcts;

        [SerializeField] private ViewComponent viewComponent;

        protected void Configure(IContainerBuilder builder)
        {
            List<IScopedObjectResolver> scopeCreated = new();
            builder.RegisterBuildCallback(resolver =>
            {
                foreach (var installer in InstallerObejcts)
                {
                    scopeCreated.Add(resolver.CreateScope(installer.Install));
                }
            });
        }

    }
}
