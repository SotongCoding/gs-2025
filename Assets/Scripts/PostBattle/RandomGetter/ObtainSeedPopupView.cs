using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace SotongStudio
{
    public interface IObtainSeedPopupView
    {
        UnityEvent OnConfirmButtonClick { get; }

        void ShowObtainPopup();
        void Hide();
    }
    public class ObtainSeedPopupView : MonoBehaviour, IObtainSeedPopupView
    {
        [SerializeField]
        private CanvasGroup _randomGetCanvas;
        [SerializeField]
        private Button _confirmButton;

        public UnityEvent OnConfirmButtonClick => _confirmButton.onClick;

        public void ShowObtainPopup()
        {
            _randomGetCanvas.Show();
        }

        public void Hide()
        {
            _randomGetCanvas.Hide();
        }
    }
}
