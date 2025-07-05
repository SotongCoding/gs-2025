using UnityEngine;
using UnityEngine.Events;
using VContainer.Unity;

namespace SotongStudio
{
    public interface IObtainSeedLogic
    {
        public UnityEvent OnDoneObtainSeed { get; }
        void AddSeedToInventory();

        void Hide();
    }

    public class ObtainSeedLogic : IObtainSeedLogic , ITickable
    {
        private readonly IPlayerSeedService _seedService;
        private readonly ISeedDataFactory _seedDataFactory;

        private readonly IObtainSeedPopupView _view;
        private readonly SeedVisualView _seedVisual;
        private bool _isShow;

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
            if (getedSeed != null)
            {
                _seedVisual.ShowSeedAs(getedSeed.VisualData.TopPart,
                                       getedSeed.VisualData.MiddlePart,
                                       getedSeed.VisualData.BottomPart);
            }

            _view.ShowObtainPopup();

            _isShow = true;
        }

        public void Hide()
        {
            _isShow = false;
            _view.Hide();
        }

        public void Tick()
        {
            if(!_isShow) { return; }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                OnDoneObtainSeed.Invoke();
            }
        }

        private ISeedData RandomizeSeedObtain()
        {
            var allPossibleSeeds = _seedService.GetNonOwnedRegularSeedIds();
            if (allPossibleSeeds.Length == 0)
            {
                return null;
            }
            var selectedSeedIndex = Random.Range(0, allPossibleSeeds.Length);
            var selectedSeedId = allPossibleSeeds[selectedSeedIndex];

            _seedService.AddRegularSeedToInventory(selectedSeedId);
            return _seedDataFactory.CreateSeedInventoryDataFromRegularId(selectedSeedId);
        }
    }
}
