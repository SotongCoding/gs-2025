using System;
using NaughtyAttributes;
using UnityEngine;
using VContainer;

namespace SotongStudio
{
    public class SeedTest : MonoBehaviour
    {
        private IPlayerSeedService _seedDataService;
        private string[] _noneOwned;
        private ISeedInventoryLogic _inventoryLogic;

        [Inject]
        private void Inject(IPlayerSeedService seedDataService)
        {

            _seedDataService = seedDataService;
            
            _noneOwned = seedDataService.GetNonOwnedRegularSeedIds();
        }

        [Inject]
        private void OtherInject(ISeedInventoryLogic inventoryLogic)
        {
            _inventoryLogic = inventoryLogic;

            inventoryLogic.OnSelectSeed.AddListener(SelectSeed);
        }

        private void SelectSeed(ISeedData seedData)
        {
            Debug.Log($"select Seed : { seedData.SeedId}");
        }

        [Button]
        public void Test()
        {
            var seedInventory = _seedDataService.GetOwnedSeeds();
            foreach (var item in seedInventory)
            {
                Debug.Log($"Owned Seed : {item}");
            }
        }

        [Button]
        public void TestAddSeedToInventory()
        {
            _seedDataService.AddRegularSeedToInventory("SEED-001");

            Debug.Log("Added Seed");
        }

        [Button]
        public void TestInventory()
        {
            _inventoryLogic.UpdateInventoryList();
        }
    }
}
