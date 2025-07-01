using UnityEngine;
using VContainer;

namespace SotongStudio
{
    public class SeedDIInstaller : ScopeInstallHelper
    {
        public override void Install(IContainerBuilder builder)
        {
            builder.Register<PlayerSeedDataService>(Lifetime.Singleton).As<IPlayerSeedDataService>();
        }
    }
}
