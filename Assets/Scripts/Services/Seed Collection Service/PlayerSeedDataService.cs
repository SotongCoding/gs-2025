#nullable enable


using System.Collections.Generic;
using System.Linq;

namespace SotongStudio
{
    public interface IPlayerSeedDataService
    {
        void AddCollectionSeedToInventory(string seedId);
        string[] GetNonOwnedSeeds();
        string[] GetOwnedSeeds();
    }

    public class PlayerSeedDataService : IPlayerSeedDataService
    {
        private readonly SeedConfigCollection _seedCollection;
        private readonly ICharacterSeedInventoryProvider _seedInventory;
        private readonly ICharacterSeedInventoryProviderUpdate _seedInventoryUpdate;
        private readonly ISeedDataFactory _seedDataFactory;

        private List<string> _seedRecord = new();

        public PlayerSeedDataService(SeedConfigCollection seedCollection,
                                     ICharacterSeedInventoryProvider seedInventory,
                                     ICharacterSeedInventoryProviderUpdate seedInventoryUpdate,
                                     ISeedDataFactory seedDataFactory)
        {
            _seedCollection = seedCollection;
            _seedInventory = seedInventory;
            _seedInventoryUpdate = seedInventoryUpdate;
            _seedDataFactory = seedDataFactory;

        }

        public void AddCollectionSeedToInventory(string seedId)
        {
            if (_seedRecord.Contains(seedId)) throw new System.InvalidOperationException("Trying Add Already added Collection Seed");

            var seedInvenData = _seedDataFactory.CreateSeedInventoryData(seedId);
            _seedInventoryUpdate.AddSeed(seedInvenData);

            _seedRecord.Add(seedId);
        }

        public string[] GetNonOwnedSeeds()
        {
            return _seedCollection.GetAllItems()
                   .Select(collectionData => collectionData.ItemId)
                   .Except(_seedRecord)
                   .ToArray();
        }

        public string[] GetOwnedSeeds()
        {
            return _seedInventory.GetAllOwnedSeedsIds().ToArray();
        }
    }
}
