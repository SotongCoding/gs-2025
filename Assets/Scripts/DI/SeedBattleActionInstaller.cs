using System.Collections.Generic;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace SotongStudio
{
    public class SeedBattleActionInstaller : ScopeInstallHelper
    {
        [SerializeField] private List<SeedInventoryItemLogic> _itemLogics;
        [SerializeField] private SeedInfoView _infoView;
        [SerializeField] private SeedInventoryView _inventoryView;
        [SerializeField] private FightActionView _fightView;
        [SerializeField] private QuickActionController _quickActionControl;

        public override void Install(IContainerBuilder builder)
        {
            builder.Register<SeedInventoryLogic>(Lifetime.Singleton).As<ISeedInventoryLogic>()
                     .WithParameter<IReadOnlyList<ISeedInventoryItemLogic>>(_itemLogics)
                     .WithParameter<ISeedInventoryView>(_inventoryView);

            builder.Register<SeedInfoLogic>(Lifetime.Singleton).As<ISeedInfoLogic>()
                .WithParameter<ISeedInfoView>(_infoView);

            builder.Register<PlayerBattleActionController>(Lifetime.Singleton).As<IPlayerBattleActionController>()
                    .WithParameter<IFightActionView>(_fightView);

            builder.RegisterComponent(_quickActionControl);
        }
    }
}
