using UnityEngine;
using UnityEngine.Events;

namespace SotongStudio
{
    public interface IObtainSeedLogic
    {
        public UnityEvent OnDoneObtainSeed { get; }
        void AddSeedToInventory();

        void Hide();
    }

    public class ObtainSeedLogic : IObtainSeedLogic
    {
        private readonly IPlayerSeedService _seedService;
        private readonly ISeedDataFactory _seedDataFactory;

        private readonly IObtainSeedPopupView _view;
        private readonly SeedVisualView _seedVisual;

        public ObtainSeedLogic(IPlayerSeedService seedService,
                               ISeedDataFactory seedDataFactory,
                               IObtainSeedPopupView view,
                               SeedVisualView seedVisual)
        {
            _seedService = seedService;
            _seedDataFactory = seedDataFactory;
            _view = view;
            _seedVisual = seedVisual;
        }

        public UnityEvent OnDoneObtainSeed => _view.OnConfirmButtonClick;

        public void AddSeedToInventory()
        {
            var getedSeed = RandomizeSeedObtain();

            _seedVisual.ShowSeedAs(getedSeed.VisualData.TopPart,
                                   getedSeed.VisualData.MiddlePart,
                                   getedSeed.VisualData.BottomPart);

            _view.ShowObtainPopup();
        }

        public void Hide()
        {
            _view.Hide();
        }

        private ISeedData RandomizeSeedObtain()
        {
            var allPossibleSeeds = _seedService.GetNonOwnedRegularSeedIds();
            var selectedSeedIndex = Random.Range(0, allPossibleSeeds.Length);
            var selectedSeedId = allPossibleSeeds[selectedSeedIndex];

            _seedService.AddRegularSeedToInventory(selectedSeedId);
            return _seedDataFactory.CreateSeedInventoryDataFromRegularId(selectedSeedId);
        }
    }
}
