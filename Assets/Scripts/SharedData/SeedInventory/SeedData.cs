namespace SotongStudio
{
    public interface ISeedData
    {
        string SeedId { get; }

        SeedInfoData InfoData { get; }
        SeedVisualData VisualData { get; }
        SeedBlessingData BlessingData { get; }

        public string[] UseBehaviours { get; }
        public string[] ThrowBehaviours { get; }
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
            UseBehaviours = useBehaviours;
            ThrowBehaviours = throwBehaviours;
        }

        public string SeedId { get; private set; }
        public SeedInfoData InfoData { get; }
        public SeedVisualData VisualData { get; private set; }
        public SeedBlessingData BlessingData { get; private set; }
        public string[] UseBehaviours { get; private set; }
        public string[] ThrowBehaviours { get; private set; }
    }
}
