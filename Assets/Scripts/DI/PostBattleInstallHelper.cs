using UnityEngine;
using VContainer;

namespace SotongStudio
{
    public class PostBattleInstallHelper : ScopeInstallHelper
    {
        [Header("Main")]
        [SerializeField]
        private PostBattleView _postbattleView;

        [Header("Get Seed")]
        [SerializeField]
        private ObtainSeedPopupView _obtainSeedView;
        [SerializeField]
        private SeedVisualView _seedVisual;

        [Header("Combine Seed")]
        [SerializeField]
        private CombineSeedView _combineSeedView;
        public override void Install(IContainerBuilder builder)
        {
            builder.Register<PostBattleController>(Lifetime.Singleton).As<IPostBattleControlller>()
                   .WithParameter<IPostBattleView>(_postbattleView);

            builder.Register<ObtainSeedLogic>(Lifetime.Singleton).As<IObtainSeedLogic>()
                .WithParameter(_seedVisual)
                .WithParameter<IObtainSeedPopupView>(_obtainSeedView);

            builder.Register<CombineSeedLogic>(Lifetime.Singleton).As<ICombineSeedLogic>()
                   .WithParameter<ICombineSeedView>(_combineSeedView);
        }
    }
}
