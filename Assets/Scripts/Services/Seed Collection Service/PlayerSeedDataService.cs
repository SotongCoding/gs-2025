#nullable enable


using System.Linq;
using SotongStudio.SharedData.PredefinedData;

namespace SotongStudio
{
    public interface IPlayerSeedDataService
    {
        string[] GetNonOwnedSeeds();
    }

    public class PlayerSeedDataService : IPlayerSeedDataService
    {
        private readonly SeedConfigCollection _seedCollection;

        public PlayerSeedDataService(SeedConfigCollection seedCollection)
        {
            _seedCollection = seedCollection;
        }

        public string[] GetNonOwnedSeeds()
        {
            return _seedCollection.GetAllItems()
                   .Select(collectionData => collectionData.ItemId)
                   .ToArray();
        }
    }
}
