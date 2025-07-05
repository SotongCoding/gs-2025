using UnityEngine;

namespace SotongStudio
{
    public interface ICombinedSeed : ISeedData
    {
        
    }
    public class CombinedSeed : SeedData, ICombinedSeed
    {
        public CombinedSeed(string seedId, SeedInfoData infoData, 
                            SeedVisualData visualData,
                            SeedBlessingData blessingData,

                            string[] useBehaviours,
                            string[] throwBehaviours) : 
                            base(seedId, infoData, visualData, blessingData, useBehaviours, throwBehaviours)
        {
        }
    }
}
