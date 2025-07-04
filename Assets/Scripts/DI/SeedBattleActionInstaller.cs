using System.Collections.Generic;
using UnityEngine;
using VContainer;

namespace SotongStudio
{
    public class SeedBattleActionInstaller : ScopeInstallHelper
    {
        [SerializeField] private List<SeedInventoryItemLogic> _itemLogics;
        [SerializeField] private SeedInfoView _infoView;

        public override void Install(IContainerBuilder builder)
        {
            builder.Register<SeedInventoryLogic>(Lifetime.Singleton).As<ISeedInventoryLogic>()
                     .WithParameter<IReadOnlyList<ISeedInventoryItemLogic>>(_itemLogics);

            builder.Register<SeedInfoLogic>(Lifetime.Singleton).As<ISeedInfoLogic>()
                .WithParameter<ISeedInfoView>(_infoView);

            builder.Register<PlayerBattleActionController>(Lifetime.Singleton).As<IPlayerBattleActionController>();
        }
    }
}
