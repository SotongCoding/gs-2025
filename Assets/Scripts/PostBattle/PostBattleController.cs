using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

namespace SotongStudio
{
    public interface IPostBattleControlller
    {
        UnityEvent OnDonePostBattle { get; }
        UniTask DoPostBattleSequenceAsync();
    }
    public class PostBattleController : IPostBattleControlller
    {
        public UnityEvent OnDonePostBattle { get; private set; } = new();

        private readonly IPostBattleView _view;

        private readonly IObtainSeedLogic _obtainSeedLogic;
        private readonly ICombineSeedLogic _combineSeedLogic;
        private readonly ISeedInventoryLogic _seedInventory;
        private bool _isPostBattle;

        public PostBattleController(IObtainSeedLogic obtainSeedLogic,
                                    ICombineSeedLogic combineSeedLogic,
                                    ISeedInventoryLogic seedInventoryLogic,
                                    IPostBattleView view)
        {
            _obtainSeedLogic = obtainSeedLogic;
            _combineSeedLogic = combineSeedLogic;
            _seedInventory = seedInventoryLogic;

            _seedInventory.OnSelectSeed.AddListener(SelectCombinedSeed);
            _combineSeedLogic.OnCombineAction.AddListener(DoCombineSeed);
            _view = view;
        }

        private void SelectCombinedSeed(ISeedData seedData)
        {
            if (!_isPostBattle)
            {
                return;
            }

            _combineSeedLogic.AddSelectedSeed(seedData);
        }
        private void DoCombineSeed()
        {
            if (!_isPostBattle)
            {
                return;
            }
            _combineSeedLogic.DoCombineProcess();
            _seedInventory.UpdateInventoryList();
        }
        public async UniTask DoPostBattleSequenceAsync()
        {
            _isPostBattle = true;

            _view.Show();

            _obtainSeedLogic.AddSeedToInventory();
            _seedInventory.UpdateInventoryList();

            await _obtainSeedLogic.OnDoneObtainSeed.OnInvokeAsync(default);
            _obtainSeedLogic.Hide();

            _combineSeedLogic.Show();
            _seedInventory.ShowInventory();


            await UniTask.WaitForSeconds(0.5f);
            await _combineSeedLogic.OnCloseCombinedSeed.OnInvokeAsync(default);
            _combineSeedLogic.Hide();
            _seedInventory.HideInventory();

            _view.Hide();
            _isPostBattle = false;
        }
    }
}
