#nullable enable


using System.Linq;

namespace SotongStudio
{
    public interface IPlayerSeedDataService
    {
        void AddSeedToInventory(ISeedData createdSeed);
        string[] GetNonOwnedSeeds();
        string[] GetOwnedSeeds();
    }

    public class PlayerSeedDataService : IPlayerSeedDataService
    {
        private readonly SeedConfigCollection _seedCollection;
        private readonly ICharacterSeedInventoryProvider _seedInventory;
        private readonly ICharacterSeedInventoryProviderUpdate _seedInventoryUpdate;

        public PlayerSeedDataService(SeedConfigCollection seedCollection,
                                     ICharacterSeedInventoryProvider seedInventory,
                                     ICharacterSeedInventoryProviderUpdate seedInventoryUpdate)
        {
            _seedCollection = seedCollection;
            _seedInventory = seedInventory;
            _seedInventoryUpdate = seedInventoryUpdate;

        }

        public void AddSeedToInventory(ISeedData createdSeed)
        {
            _seedInventoryUpdate.AddSeed(createdSeed);
        }

        public string[] GetNonOwnedSeeds()
        {
            return _seedCollection.GetAllItems()
                   .Select(collectionData => collectionData.ItemId)
                   .ToArray();
        }

        public string[] GetOwnedSeeds()
        {
            return _seedInventory.GetAllOwnedSeedsIds().ToArray();
        }
    }
}
