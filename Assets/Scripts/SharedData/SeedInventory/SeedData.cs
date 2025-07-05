namespace SotongStudio
{
    public interface ISeedData
    {
        string SeedId { get; }

        SeedInfoData InfoData { get; }
        SeedVisualData VisualData { get; }
        SeedBlessingData BlessingData { get; }

        public string[] UseBehaviourIds { get; }
        public string[] ThrowBehaviourIds { get; }
    }

    public class SeedData : ISeedData
    {
        public SeedData(string seedId,
                        SeedInfoData infoData,
                        SeedVisualData visualData,
                        SeedBlessingData blessingData,
                        string[] useBehaviours, 
                        string[] throwBehaviours)
        {
            SeedId = seedId;
            InfoData = infoData;
            VisualData = visualData;
            BlessingData = blessingData;
            UseBehaviourIds = useBehaviours;
            ThrowBehaviourIds = throwBehaviours;
        }

        public string SeedId { get; private set; }
        public SeedInfoData InfoData { get; }
        public SeedVisualData VisualData { get; private set; }
        public SeedBlessingData BlessingData { get; private set; }
        public string[] UseBehaviourIds { get; private set; }
        public string[] ThrowBehaviourIds { get; private set; }
    }
}
