using System;
using System.Collections.Generic;
using System.Linq;

#nullable enable

namespace SotongStudio
{
    public interface ISeedDataFactory
    {
        ICombinedSeed CreateCombinedSeed(IEnumerable<ISeedData> selectedSeeds);
        ISeedData CreateSeedInventoryDataFromRegularId(string seedId);
    }
    public class SeedDataFactory : ISeedDataFactory
    {
        private readonly SeedConfigCollection _seedConfigCollection;

        public SeedDataFactory(SeedConfigCollection seedConfigCollection)
        {
            _seedConfigCollection = seedConfigCollection;
        }

        public ICombinedSeed CreateCombinedSeed(IEnumerable<ISeedData> selectedSeeds)
        {
            ISeedData firstSeed = selectedSeeds.ElementAtOrDefault(0);
            ISeedData? secondSeed = selectedSeeds.ElementAtOrDefault(1);
            ISeedData? thirdSeed = selectedSeeds.ElementAtOrDefault(2);

            var topVisual = firstSeed.VisualData.TopPart;
            var middleVisual = secondSeed?.VisualData.MiddlePart ?? throw new System.InvalidOperationException("Second seed is required for combining.");
            var bottomVisual = thirdSeed?.VisualData.BottomPart ?? secondSeed.VisualData.BottomPart;

            var combinedVisualData = new SeedVisualData(topVisual, middleVisual, bottomVisual);

            List<string> useBehaviours = new();
            useBehaviours.AddRange(firstSeed.UseBehaviourIds);
            useBehaviours.AddRange(secondSeed?.UseBehaviourIds ?? Array.Empty<string>());
            useBehaviours.AddRange(thirdSeed?.UseBehaviourIds ?? Array.Empty<string>());

            List<string> throwBehaviours = new();
            throwBehaviours.AddRange(firstSeed.ThrowBehaviourIds);
            throwBehaviours.AddRange(secondSeed?.ThrowBehaviourIds ?? Array.Empty<string>());
            throwBehaviours.AddRange(thirdSeed?.ThrowBehaviourIds ?? Array.Empty<string>());

            return new CombinedSeed(firstSeed.SeedId + secondSeed?.SeedId + thirdSeed?.SeedId,
                                        firstSeed.InfoData,
                                        combinedVisualData,
                                        firstSeed.BlessingData,
                                        useBehaviours.ToArray(),
                                        throwBehaviours.ToArray());

        }

        public ISeedData CreateSeedInventoryDataFromRegularId(string seedId)
        {
            var seedConfig = _seedConfigCollection.GetItem(seedId);

            return new SeedData(seedConfig.ItemId,
                                seedConfig.InfoData,
                                seedConfig.VisualData,
                                seedConfig.BlessingData,

                                new[] { seedConfig.UseBehavioursIds },
                                new[] { seedConfig.ThrowBehavioursIds });
        }
    }
}
