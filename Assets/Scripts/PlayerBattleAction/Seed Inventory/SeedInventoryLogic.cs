using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.Events;

namespace SotongStudio
{
    public interface ISeedInventoryLogic
    {
        UnityEvent<ISeedData> OnSelectSeed { get; }
        void UpdateInventoryList();
        
    }
    public class SeedInventoryLogic : ISeedInventoryLogic
    {

        private readonly IPlayerSeedService _seedDataService;
        private readonly IReadOnlyList<ISeedInventoryItemLogic> _inventoryItems;
        public UnityEvent<ISeedData> OnSelectSeed { get; private set; } = new();

        public SeedInventoryLogic(IPlayerSeedService seedDataService,
                                  IReadOnlyList<ISeedInventoryItemLogic> inventoryItems)
        {
            _seedDataService = seedDataService;
            _inventoryItems = inventoryItems;

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
    }
}
