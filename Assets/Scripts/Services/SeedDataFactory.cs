using System;

namespace SotongStudio
{
    public interface ISeedDataFactory
    {
        ISeedData CreateSeedInventoryDataFromRegularId(string seedId);
    }
    public class SeedDataFactory : ISeedDataFactory
    {
        private readonly SeedConfigCollection _seedConfigCollection;

        public SeedDataFactory(SeedConfigCollection seedConfigCollection)
        {
            _seedConfigCollection = seedConfigCollection;
        }

        public ISeedData CreateSeedInventoryDataFromRegularId(string seedId)
        {
            var seedConfig = _seedConfigCollection.GetItem(seedId);

            return new SeedData(seedConfig.ItemId,
                                seedConfig.InfoData,
                                seedConfig.VisualData,
                                seedConfig.BlessingData,

                                Array.Empty<string>(),
                                Array.Empty<string>());
        }
    }
}
