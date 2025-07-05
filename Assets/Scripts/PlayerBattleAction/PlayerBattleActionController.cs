#nullable enable

using System.Net.NetworkInformation;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using UnityEngine;
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
        private readonly IPlayerSeedService _seedService;

        private ISeedData? _currentSelectedSeed;
        private bool _isBattle;

        public PlayerBattleActionController(SeedBehaviourCollection behaviourCollection,
                                            IBattleHelper battleHelper,
                                            ISeedInfoLogic seedInfoLogic,
                                            ISeedInventoryLogic seedInventoryLogic,
                                            IFightActionView fightView,
                                            IPlayerSeedService seedService)
        {
            _behaviourCollection = behaviourCollection;
            _battleHelper = battleHelper;
            _seedInfoLogic = seedInfoLogic;
            _seedInventoryLogic = seedInventoryLogic;
            _seedService = seedService;


            _seedInventoryLogic.OnSelectSeed.AddListener(UpdateCurrentSeed);

            _seedInfoLogic.OnUseSeed.AddListener(UseSelectedSeed);
            _seedInfoLogic.OnThrowSeed.AddListener(ThrowSelectedSeed);
            _fightView = fightView;

            _fightView.OnStartQA.AddListener(StartFight);

        }

        private void UpdateCurrentSeed(ISeedData selectedSeed)
        {
            if (!_isBattle) { return; }

            if (selectedSeed == null)
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
        private async UniTask ThrowSelectedSeedAsync()
        {
            if (_currentSelectedSeed == null)
            {
                return;
            }

            Debug.Log("Do Throw Logic");

            using var _ = ListPool<UniTask>.Get(out var executeTask);

            foreach (var behavId in _currentSelectedSeed.ThrowBehaviourIds)
            {
                var behaviour = _behaviourCollection.GetItem(behavId);
                var executeProcess = behaviour.ThrowLogic.ExecuteBehaviourAsync(_battleHelper);

                executeTask.Add(executeProcess);
            }

            await UniTask.WhenAll(executeTask);

            CloseSeedInfo();
            UseSeed(_currentSelectedSeed);
        }


        public void UseSelectedSeed()
        {
            UseSelectedSeedAsync().Forget();
        }
        private async UniTask UseSelectedSeedAsync()
        {
            if (_currentSelectedSeed == null)
            {
                return;
            }

            Debug.Log("Do Use Logic");

            using var _ = ListPool<UniTask>.Get(out var executeTask);

            foreach (var behavId in _currentSelectedSeed.UseBehaviourIds)
            {
                var behaviour = _behaviourCollection.GetItem(behavId);
                var executeProcess = behaviour.UseLogic.ExecuteBehaviourAsync(_battleHelper);

                executeTask.Add(executeProcess);
            }

            await UniTask.WhenAll(executeTask);

            CloseSeedInfo();
            UseSeed(_currentSelectedSeed);
        }

        private void UseSeed(ISeedData currentSelectedSeed)
        {
            _seedService.RemoveSeedFromInventory(currentSelectedSeed);
            _seedInventoryLogic.UpdateInventoryList();
            _currentSelectedSeed = null;
        }
        private void CloseSeedInfo()
        {
            _seedInfoLogic.HideSeedInfo();
        }

        private void StartFight()
        {
            OnStartQA?.Invoke();
        }

        public void ShowPreBattleUI()
        {
            _isBattle = true; //TODO Need better Handling for Select Seed in Combine and Battle

            _fightView.Show();
            _seedInventoryLogic.UpdateInventoryList();
            _seedInventoryLogic.ShowInventory();
        }

        public void HidePreBattleUI()
        {
            _isBattle = false; //TODO Need better Handling for Select Seed in Combine and Battle

            _fightView.Hide();
            _seedInventoryLogic.HideInventory();
            _seedInfoLogic.HideSeedInfo();
        }
    }
}
