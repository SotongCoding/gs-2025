using UnityEngine;
using VContainer;

namespace SotongStudio
{
    public class TurnBasedInstaller : ScopeInstallHelper
    {
        public override void Install(IContainerBuilder builder)
        {
            builder.Register<BattleSystemController>(Lifetime.Singleton);
        }
    }
}
