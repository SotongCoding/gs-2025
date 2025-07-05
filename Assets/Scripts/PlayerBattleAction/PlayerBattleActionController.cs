#nullable enable

using Cysharp.Threading.Tasks;
using UnityEngine.Events;
using UnityEngine.Pool;

namespace SotongStudio
{
    public interface IPlayerBattleActionController
    {
        UnityEvent OnStartQA { get; }
        void UseSelectedSeed();
        void ThrowSelectedSeed();

        void ClearSelectedSeed();

        void ShowPreBattleUI();
        void HidePreBattleUI();
    }
    public class PlayerBattleActionController : IPlayerBattleActionController
    {
        public UnityEvent OnStartQA { get; private set; } = new();

        private readonly SeedBehaviourCollection _behaviourCollection;
        private readonly IBattleHelper _battleHelper;

        private readonly ISeedInfoLogic _seedInfoLogic;
        private readonly ISeedInventoryLogic _seedInventoryLogic;
        private readonly IFightActionView _fightView;
        private ISeedData? _currentSelectedSeed;

        public PlayerBattleActionController(SeedBehaviourCollection behaviourCollection,
                                            IBattleHelper battleHelper,
                                            ISeedInfoLogic seedInfoLogic,
                                            ISeedInventoryLogic seedInventoryLogic,
                                            IFightActionView fightView)
        {
            _behaviourCollection = behaviourCollection;
            _battleHelper = battleHelper;
            _seedInfoLogic = seedInfoLogic;
            _seedInventoryLogic = seedInventoryLogic;


            _seedInventoryLogic.OnSelectSeed.AddListener(UpdateCurrentSeed);

            _seedInfoLogic.OnUseSeed.AddListener(UseSelectedSeed);
            _seedInfoLogic.OnThrowSeed.AddListener(ThrowSelectedSeed);
            _fightView = fightView;

            _fightView.OnStartQA.AddListener(StartFight);

        }

        private void UpdateCurrentSeed(ISeedData selectedSeed)
        {
            if(selectedSeed == null)
            {
                _seedInfoLogic.HideSeedInfo();
                return;
            }
            _currentSelectedSeed = selectedSeed;
            _seedInfoLogic.ShowSeedInfo(selectedSeed);
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
    
        private void StartFight()
        {
           OnStartQA?.Invoke();
        }

        public void ShowPreBattleUI()
        {
            _fightView.Show();
            _seedInventoryLogic.UpdateInventoryList();
            _seedInventoryLogic.ShowInventory();
        }

        public void HidePreBattleUI()
        {
            _fightView.Hide();
            _seedInventoryLogic.HideInventory();
            _seedInfoLogic.HideSeedInfo();
        }
    }
}
