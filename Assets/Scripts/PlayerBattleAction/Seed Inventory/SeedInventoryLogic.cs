using System.Collections.Generic;
using System.Linq;
using UnityEngine.Events;

namespace SotongStudio
{
    public interface ISeedInventoryLogic
    {
        UnityEvent<ISeedData> OnSelectSeed { get; }
        void UpdateInventoryList();

        void ShowInventory();
        void HideInventory();
        
    }
    public class SeedInventoryLogic : ISeedInventoryLogic
    {
        private readonly ISeedInventoryView _view;
        private readonly IPlayerSeedService _seedDataService;
        private readonly IReadOnlyList<ISeedInventoryItemLogic> _inventoryItems;
        public UnityEvent<ISeedData> OnSelectSeed { get; private set; } = new();

        public SeedInventoryLogic(IPlayerSeedService seedDataService,
                                  IReadOnlyList<ISeedInventoryItemLogic> inventoryItems,
                                  ISeedInventoryView view)
        {
            _seedDataService = seedDataService;
            _inventoryItems = inventoryItems;
            _view = view;

            foreach (var item in inventoryItems)
            {
                item.OnSelectSeed.AddListener(SelectedSeed);
            }
        }

        private void SelectedSeed(ISeedData seedData)
        {
            OnSelectSeed?.Invoke(seedData);
        }

        public void UpdateInventoryList()
        {
            var seeds = _seedDataService.GetOwnedSeeds();
            var amount = seeds.Count();

            for (int i = 0; i < amount; i++)
            {
                _inventoryItems[i].SetupSeedItem(seeds.ElementAt(i));
            }
            for (int i = amount; i < _inventoryItems.Count; i++)
            {
                _inventoryItems[i].ClearSeedVisual();
            }
        }

        public void ShowInventory()
        {
            _view.Show();
        }

        public void HideInventory()
        {
            _view.Hide();
        }
    }
}
