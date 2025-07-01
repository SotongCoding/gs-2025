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
        private List<ISeedData> _currentHavedSeed = new List<ISeedData>();

        public void AddSeed(ISeedData data)
        {
            if (!_currentHavedSeed.Contains(data))
            {
                _currentHavedSeed.Add(data);
            }
            else
            {
                Debug.LogWarning("Seed already exists in the inventory.");
            }
        }

        public void RemoveSeed(ISeedData data)
        {
            _currentHavedSeed.Remove(data);
        }

        public IEnumerable<ISeedData> GetAllOwnedSeeds()
        {
            return _currentHavedSeed;
        }

        public IEnumerable<string> GetAllOwnedSeedsIds()
        {
            return _currentHavedSeed.Select(data => data.SeedId);
        }
    }
}
