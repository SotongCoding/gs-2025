using SotongStudio.VContainer;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace SotongStudio.Plugins.DI
{
    public class SceneScope : LifetimeScope
    {
        [SerializeField] private ScriptInstaller[] _installers;
        [SerializeField] private ScriptInstaller[] _childScopeInstaller;
        [SerializeField] private MonoBehaviour[] _gameObject;
        protected override void Configure(IContainerBuilder builder)
        {
            
            AdditionalRegistration(builder);

            foreach (var installer in _installers)
            {
                installer.Install(builder);
            }
            VContainerDIInstallerUtils.RegisterMonoBehaviourComponents(builder, _gameObject);

            base.Configure(builder);
        }
        protected virtual IContainerBuilder AdditionalRegistration(IContainerBuilder builder)
        {
            return builder;
        }

        protected override void Awake()
        {
            base.Awake();
            Build();
            foreach (var installer in _childScopeInstaller)
            {
                installer.CreateChild(this);
            }
        }
    }
}
