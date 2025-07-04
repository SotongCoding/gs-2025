using System.Collections.Generic;
using UnityEngine;
using VContainer;

namespace SotongStudio
{
    public class SeedInventoryInstaller : ScopeInstallHelper
    {
        [SerializeField] private List<SeedInventoryItemLogic> _itemLogics;

        public override void Install(IContainerBuilder builder)
        {
            builder.Register<SeedInventoryLogic>(Lifetime.Singleton).As<ISeedInventoryLogic>()
                     .WithParameter<IReadOnlyList<ISeedInventoryItemLogic>>(_itemLogics);
                  
        }
    }
}
