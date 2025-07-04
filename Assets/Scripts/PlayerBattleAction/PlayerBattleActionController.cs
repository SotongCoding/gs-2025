#nullable enable

using Cysharp.Threading.Tasks;
using UnityEngine.Pool;

namespace SotongStudio
{
    public interface IPlayerBattleActionController
    {
        void UseSelectedSeed();
        void ThrowSelectedSeed();

        void ClearSelectedSeed();
    }
    public class PlayerBattleActionController : IPlayerBattleActionController
    {
        private readonly SeedBehaviourCollection _behaviourCollection;
        private readonly IBattleHelper _battleHelper;

        private readonly ISeedInfoLogic _seedInfoLogic;
        private readonly ISeedInventoryLogic _seedInventoryLogic;

        private ISeedData? _currentSelectedSeed;

        public PlayerBattleActionController(SeedBehaviourCollection behaviourCollection,
                                            IBattleHelper battleHelper,
                                            ISeedInfoLogic seedInfoLogic,
                                            ISeedInventoryLogic seedInventoryLogic)
        {
            _behaviourCollection = behaviourCollection;
            _battleHelper = battleHelper;
            _seedInfoLogic = seedInfoLogic;
            _seedInventoryLogic = seedInventoryLogic;


            _seedInventoryLogic.OnSelectSeed.AddListener(UpdateCurrentSeed);

            _seedInfoLogic.OnUseSeed.AddListener(UseSelectedSeed);
            _seedInfoLogic.OnThrowSeed.AddListener(ThrowSelectedSeed);
        }

        private void UpdateCurrentSeed(ISeedData selectedSeed)
        {
            _currentSelectedSeed = selectedSeed;
        }

        public void ClearSelectedSeed()
        {
            _currentSelectedSeed = null;
        }

        public void ThrowSelectedSeed()
        {
            ThrowSelectedSeedAsync().Forget();
        }
        private UniTask ThrowSelectedSeedAsync()
        {
            if (_currentSelectedSeed == null)
            {
                return UniTask.CompletedTask;
            }

            using var _ = ListPool<UniTask>.Get(out var executeTask);

            foreach (var behavId in _currentSelectedSeed.ThrowBehaviourIds)
            {
                var behaviour = _behaviourCollection.GetItem(behavId);
                var executeProcess = behaviour.ThrowLogic.ExecuteBehaviourAsync(_battleHelper);

                executeTask.Add(executeProcess);
            }

            return UniTask.WhenAll(executeTask);
        }


        public void UseSelectedSeed()
        {
            UseSelectedSeedAsync().Forget();
        }
        private UniTask UseSelectedSeedAsync()
        {
            if (_currentSelectedSeed == null)
            {
                return UniTask.CompletedTask;
            }

            using var _ = ListPool<UniTask>.Get(out var executeTask);

            foreach (var behavId in _currentSelectedSeed.UseBehaviourIds)
            {
                var behaviour = _behaviourCollection.GetItem(behavId);
                var executeProcess = behaviour.UseLogic.ExecuteBehaviourAsync(_battleHelper);

                executeTask.Add(executeProcess);
            }

            return UniTask.WhenAll(executeTask);
        }
    }
}
