using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace SotongStudio
{
    public interface ICharacterSeedInventoryProviderUpdate
    {
        void AddSeed(ISeedData data);
        void RemoveSeed(ISeedData data);
    }
    public interface ICharacterSeedInventoryProvider
    {
        IEnumerable<ISeedData> GetAllOwnedSeeds();

        IEnumerable<string> GetAllOwnedSeedsIds();
    }
    public class CharacterSeedInventoryProvider : ICharacterSeedInventoryProvider, ICharacterSeedInventoryProviderUpdate
    {
        private List<ISeedData> _currentHoldSeed = new List<ISeedData>();

        public void AddSeed(ISeedData data)
        {
            if (!_currentHoldSeed.Contains(data))
            {
                _currentHoldSeed.Add(data);
            }
            else
            {
                Debug.LogWarning("Seed already exists in the inventory.");
            }
        }

        public void RemoveSeed(ISeedData data)
        {
            _currentHoldSeed.Remove(data);
        }

        public IEnumerable<ISeedData> GetAllOwnedSeeds()
        {
            return _currentHoldSeed;
        }

        public IEnumerable<string> GetAllOwnedSeedsIds()
        {
            return _currentHoldSeed.Select(data => data.SeedId);
        }
    }
}
