#nullable enable

using UnityEngine;
using UnityEngine.Events;

namespace SotongStudio
{
    public interface ISeedInventoryItemLogic
    {
        void ClearSeedVisual();
        void SetupSeedItem(ISeedData seedData);
        UnityEvent<ISeedData> OnSelectSeed { get; }
    }
    public class SeedInventoryItemLogic : MonoBehaviour, ISeedInventoryItemLogic
    {
        public UnityEvent<ISeedData> OnSelectSeed { get; private set; } = new();

        [SerializeField]
        private SeedInventoryItemView _view;
        [SerializeField]
        private SeedVisualView _seedView;

        private SeedVisualControl _visualControl;

        private ISeedData? _handledSeed;

        public void Awake()
        {
            _visualControl = new(_seedView);
            _view.OnSelectSeed.AddListener(SelectSeedProcess);
        }

        public void ClearSeedVisual()
        {
            _visualControl.HideVisual();
        }

        public void SetupSeedItem(ISeedData? seedData)
        {
            if (seedData == null)
            {
                _visualControl.HideVisual();
                _handledSeed = null;
            }
            else
            {

                _handledSeed = seedData;
                _visualControl.ShowSeedAs(seedData.VisualData.TopPart,
                                          seedData.VisualData.MiddlePart,
                                          seedData.VisualData.BottomPart);
            }
        }

        private void SelectSeedProcess()
        {
            if (_handledSeed == null)
            {
                Debug.LogWarning("No seed data is handled for selection.");
                return;
            }
            OnSelectSeed?.Invoke(_handledSeed);
        }
    }
}
