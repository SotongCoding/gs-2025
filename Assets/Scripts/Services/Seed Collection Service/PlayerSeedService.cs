#nullable enable


using System.Collections.Generic;
using System.Linq;

namespace SotongStudio
{
    public interface IPlayerSeedService
    {
        void AddRegularSeedToInventory(string seedId);
        void AddCombinedSeedToInventory(ISeedData combinedSeed);
        string[] GetNonOwnedRegularSeedIds();
        IEnumerable<ISeedData> GetOwnedSeeds();
    }

    public class PlayerSeedService : IPlayerSeedService
    {
        private readonly SeedConfigCollection _seedCollection;
        private readonly ICharacterSeedInventoryProvider _seedInventory;
        private readonly ICharacterSeedInventoryProviderUpdate _seedInventoryUpdate;
        private readonly ISeedDataFactory _seedDataFactory;

        private List<string> _regularSeedRecord = new();

        public PlayerSeedService(SeedConfigCollection seedCollection,
                                     ICharacterSeedInventoryProvider seedInventory,
                                     ICharacterSeedInventoryProviderUpdate seedInventoryUpdate,
                                     ISeedDataFactory seedDataFactory)
        {
            _seedCollection = seedCollection;
            _seedInventory = seedInventory;
            _seedInventoryUpdate = seedInventoryUpdate;
            _seedDataFactory = seedDataFactory;

        }

        public void AddCombinedSeedToInventory(ISeedData combinedSeed)
        {
            _seedInventoryUpdate.AddSeed(combinedSeed);
        }

        public void AddRegularSeedToInventory(string seedId)
        {
            if (_regularSeedRecord.Contains(seedId)) throw new System.InvalidOperationException("Trying Add Already added Collection Seed");

            var seedInvenData = _seedDataFactory.CreateSeedInventoryDataFromRegularId(seedId);
            _seedInventoryUpdate.AddSeed(seedInvenData);

            _regularSeedRecord.Add(seedId);
        }

        public string[] GetNonOwnedRegularSeedIds()
        {
            return _seedCollection.GetAllItems()
                   .Select(collectionData => collectionData.ItemId)
                   .Except(_regularSeedRecord)
                   .ToArray();
        }

        public IEnumerable<ISeedData> GetOwnedSeeds()
        {
            return _seedInventory.GetAllOwnedSeeds();
        }
    }
}
