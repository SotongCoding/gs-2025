using UnityEngine;
using UnityEngine.Events;

namespace SotongStudio
{
    public interface ISeedInfoLogic
    {
        UnityEvent OnUseSeed { get; }
        UnityEvent OnThrowSeed { get; }

        void ShowSeedInfo(ISeedData seedData);
        void HideSeedInfo();
    }
    public class SeedInfoLogic : ISeedInfoLogic
    {
        private readonly ISeedInfoView _view;
        private readonly SeedBehaviourCollection _seedBehaviourCollection;

        public UnityEvent OnUseSeed => _view.OnUseSeed;
        public UnityEvent OnThrowSeed => _view.OnThrowSeed;

        public SeedInfoLogic(ISeedInfoView view,
                             SeedBehaviourCollection seedBehaviourCollection)
        {
            _view = view;
            _seedBehaviourCollection = seedBehaviourCollection;
        }

        public void ShowSeedInfo(ISeedData seedData)
        {
            ShowUseInfo(seedData.UseBehaviourIds);
            ShowThrowInfo(seedData.ThrowBehaviourIds);

            _view.Show();
        }

        private void ShowUseInfo(string[] useBehaviourIds)
        {
            string useInfoText = GenerateInfoText(useBehaviourIds);
            _view.SetUseInfoText(useInfoText);

            
        }

        private void ShowThrowInfo(string[] throwBehaviourIds)
        {
            string throwInfoText = GenerateInfoText(throwBehaviourIds);
            _view.SetThrowInfoText(throwInfoText);

            Debug.Log($"Set text : {throwInfoText}");

        }


        private string GenerateInfoText(string[] behaviourIds)
        {
            string finalText = string.Empty;
            foreach (var behavId in behaviourIds)
            {
                var behaviour = _seedBehaviourCollection.GetItem(behavId);
                Debug.Log($"Text in {behavId} - {behaviour.Description}");
                finalText = string.Concat(finalText, behaviour.Description, "\n");
            }

            return finalText;
        }

        public void HideSeedInfo()
        {
            _view.Hide();
        }
    }
}
