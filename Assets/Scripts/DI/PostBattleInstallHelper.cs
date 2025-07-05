using Cysharp.Threading.Tasks.Triggers;
using UnityEngine;
using VContainer;
using VContainer.Unity;

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

            builder.RegisterEntryPoint<ObtainSeedLogic>(Lifetime.Singleton).As<IObtainSeedLogic, ITickable>()
                .WithParameter(_seedVisual)
                .WithParameter<IObtainSeedPopupView>(_obtainSeedView);

            builder.RegisterEntryPoint<CombineSeedLogic>(Lifetime.Singleton).As<ICombineSeedLogic, ITickable>()
                   .WithParameter<ICombineSeedView>(_combineSeedView);
        }
    }
}
