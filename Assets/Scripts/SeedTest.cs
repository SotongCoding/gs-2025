using NaughtyAttributes;
using UnityEngine;
using VContainer;

namespace SotongStudio
{
    public class SeedTest : MonoBehaviour
    {
        private IPlayerSeedDataService _seedDataService;
        private string[] _noneOwned;

        [Inject]
        private void Inject(IPlayerSeedDataService seedDataService)
        {

            _seedDataService = seedDataService;
            
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
            _seedDataService.AddCollectionSeedToInventory("SEED-001");

            Debug.Log("Added Seed");
        }
    }
}
