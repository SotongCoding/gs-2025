using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace SotongStudio
{
    public class TurnBasedInstaller : ScopeInstallHelper
    {
        [SerializeField]
        private PlayerActionView _playerActionView;
        [SerializeField]
        private BattleSystemView _battleSystemView;
        [SerializeField]
        private EnemyConfigCollection _enemyConfigCollection;

        public override void Install(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<BattleSystemLogic>();
            builder.RegisterComponent(_playerActionView);
            builder.RegisterComponent(_battleSystemView);

            builder.RegisterEntryPoint<LevelManager>();
            builder.RegisterComponent(_enemyConfigCollection);
        }
    }
}
