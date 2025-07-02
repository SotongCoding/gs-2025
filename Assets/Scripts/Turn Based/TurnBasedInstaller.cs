using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace SotongStudio
{
    public class TurnBasedInstaller : ScopeInstallHelper
    {
        [SerializeField]
        private ButtonView _buttonView;
        [SerializeField]
        private BattleSystemView _battleSystemView;

        public override void Install(IContainerBuilder builder)
        {
            //builder.Register<BattleSystemControl>(Lifetime.Singleton);
            builder.RegisterEntryPoint<BattleSystemLogic>();
            builder.RegisterComponent(_buttonView);
            builder.RegisterComponent(_battleSystemView);
        }
    }
}
