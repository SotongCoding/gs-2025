using VContainer;
using VContainer.Unity;

namespace SotongStudio
{
    public class BattleDIInstaller : ScopeInstallHelper
    {
        public override void Install(IContainerBuilder builder)
        {
            builder.Register<BattleUnitManager>(Lifetime.Singleton).As<IBattleUnitManager>();
            builder.Register<BattleHelper>(Lifetime.Singleton).As<IBattleHelper>();
        }
    }
}
