using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace SotongStudio
{
    public class GameManagerDIHelper : ScopeInstallHelper
    {
        [SerializeField]
        private GameManagerView _gameManagerView;
        public override void Install(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<GameManager>(Lifetime.Singleton).AsSelf()
                    .WithParameter(_gameManagerView);

        }
    }
}
