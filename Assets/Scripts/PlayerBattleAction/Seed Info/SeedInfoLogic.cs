namespace SotongStudio
{
    public interface ISeedInfoLogic
    {
        void ShowSeedInfo(ISeedData seedData);
    }
    public class SeedInfoLogic : ISeedInfoLogic
    {
        private readonly ISeedInfoView _view;
        
        public void ShowSeedInfo(ISeedData seedData)
        {
            ShowUseInfo(seedData.UseBehaviourIds);
            ShowThrowInfo(seedData.ThrowBehaviourIds);
        }
        
        private void ShowUseInfo(string[] useBehaviourIds)
        {
            
        }

        private  void ShowThrowInfo(string[] throwBehaviourIds)
        {

        }


        private void GenerateInfoText(string[] behaviourIds)
        {

        }

    }
}
