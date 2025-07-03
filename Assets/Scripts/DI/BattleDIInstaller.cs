using VContainer;

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
