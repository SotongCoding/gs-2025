using UnityEngine;
using VContainer;

namespace SotongStudio
{
    public class SeedDIInstaller : ScopeInstallHelper
    {
        public override void Install(IContainerBuilder builder)
        {
            builder.Register<PlayerSeedService>(Lifetime.Singleton).As<IPlayerSeedService>();
            builder.Register<CharacterSeedInventoryProvider>(Lifetime.Singleton).As<ICharacterSeedInventoryProvider, 
                                                                                    ICharacterSeedInventoryProviderUpdate>();

            builder.Register<SeedDataFactory>(Lifetime.Singleton).As<ISeedDataFactory>();


        }
    }
}
