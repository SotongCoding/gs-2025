using NaughtyAttributes;
using UnityEngine;
using VContainer;

namespace SotongStudio
{
    public class SeedTest : MonoBehaviour
    {
        private string[] _noneOwned;

        [Inject]
        private void Inject(IPlayerSeedDataService seedDataService)
        {
            _noneOwned = seedDataService.GetNonOwnedSeeds();
        }

        [Button]
        public void Test()
        {
            foreach (var item in _noneOwned)
            {
                Debug.Log($"Non Owned Seed : {item}");
            }
        }
    }
}
