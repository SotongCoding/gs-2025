using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace SotongStudio
{
#nullable enable

    public interface ICombineSeedView
    {
        UnityEvent OnCombineSeedClose { get; }
        UnityEvent OnCombineSeed { get; }

        void ShowCombineSeedUI();
        void HideCombineSeedUI();
        void SetSeedVisual(int index, SeedVisualData visualData);

        void ShowCombinedSeedResult(SeedVisualData visualData);
        void ClearResult();
    }
    public class CombineSeedView : MonoBehaviour, ICombineSeedView
    {
        [SerializeField]
        private SeedVisualView[] _seedView;
        [SerializeField]
        private SeedVisualView _seedResult;

        [SerializeField]
        private CanvasGroup _combineSeedMainCanvas;

        [SerializeField]
        private Button _combineButton;

        [SerializeField]
        private Button _closeButton;

        public UnityEvent OnCombineSeedClose => _closeButton.onClick;
        public UnityEvent OnCombineSeed => _combineButton.onClick;
        public void ShowCombineSeedUI()
        {
            _combineSeedMainCanvas.Show();
        }
        public void HideCombineSeedUI()
        {
            _combineSeedMainCanvas.Hide();
        }

        public void SetSeedVisual(int index, SeedVisualData? visualData)
        {
            if (visualData == null)
            {
                _seedView[index].HideVisual();
            }
            else
            {

                _seedView[index].ShowSeedAs(visualData.TopPart,
                                            visualData.MiddlePart,
                                            visualData.BottomPart);
            }
        }

        public void ShowCombinedSeedResult(SeedVisualData visualData)
        {
            _seedResult.ShowSeedAs(visualData.TopPart,
                                            visualData.MiddlePart,
                                            visualData.BottomPart);
        }

        public void ClearResult()
        {
            _seedResult.HideVisual();
        }
    }
}
