using UnityEngine;
using VContainer;

namespace SotongStudio
{
    public class PostBattleInstallHelper : ScopeInstallHelper
    {
        [Header("Get Seed")]
        [SerializeField]
        private ObtainSeedPopupView _obtainSeedView;
        [SerializeField]
        private SeedVisualView _seedVisual;
        public override void Install(IContainerBuilder builder)
        {
            builder.Register<PostBattleController>(Lifetime.Singleton).As<IPostBattleControlller>();

            builder.Register<ObtainSeedLogic>(Lifetime.Singleton).As<IObtainSeedLogic>()
                .WithParameter(_seedVisual)
                .WithParameter<IObtainSeedPopupView>(_obtainSeedView);
        }
    }
}
