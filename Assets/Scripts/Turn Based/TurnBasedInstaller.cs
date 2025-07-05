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
        [SerializeField]
        private BattleVisualEffect _battleVisualEffect;

        public override void Install(IContainerBuilder builder)
        {
            builder.Register<BattleSystemLogic>(Lifetime.Singleton)
                   .WithParameter(_battleVisualEffect);
            //builder.RegisterComponent(_playerActionView);
            builder.RegisterComponent(_battleSystemView);

            builder.Register<LevelManager>(Lifetime.Singleton);
            //builder.RegisterComponent(_enemyConfigCollection);
        }
    }
}
