using NaughtyAttributes;
using UnityEngine;
using VContainer;

namespace SotongStudio
{
    public class SeedTest : MonoBehaviour
    {
        private IPlayerSeedDataService _seedDataService;
        private ISeedDataFactory _seedDataFactory;
        private string[] _noneOwned;

        [Inject]
        private void Inject(IPlayerSeedDataService seedDataService,
                            ISeedDataFactory seedDataFactory)
        {

            _seedDataService = seedDataService;
            _seedDataFactory = seedDataFactory;
            
            _noneOwned = seedDataService.GetNonOwnedSeeds();
        }

        [Button]
        public void Test()
        {
            var seedInventory = _seedDataService.GetOwnedSeeds();
            foreach (var item in seedInventory)
            {
                Debug.Log($"Non Owned Seed : {item}");
            }
        }

        [Button]
        public void TestAddSeedToInventory()
        {
            var createdSeed = _seedDataFactory.CreateSeedInventoryData("SEED-001"); 
            _seedDataService.AddSeedToInventory(createdSeed);

            Debug.Log("Added Seed");
        }
    }
}
