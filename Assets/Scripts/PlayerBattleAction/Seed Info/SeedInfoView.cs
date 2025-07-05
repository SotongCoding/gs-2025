using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace SotongStudio
{
    public interface ISeedInfoView
    {
        UnityEvent OnUseSeed { get; }
        UnityEvent OnThrowSeed { get; }

        void SetThrowInfoText(string useInfoText);
        void SetUseInfoText(string useInfoText);

        void Show();
        void Hide();
    }
    public class SeedInfoView : MonoBehaviour, ISeedInfoView
    {
        public UnityEvent OnUseSeed => _useActionButton.onClick;
        public UnityEvent OnThrowSeed => _throwActionButton.onClick;


        [SerializeField]
        private TMP_Text _useText;

        [SerializeField]
        private TMP_Text _throwText;

        [SerializeField]
        private Button _useActionButton;

        [SerializeField]
        private Button _throwActionButton;


        [SerializeField]
        private CanvasGroup _seedInfoCanvas;
        public void SetThrowInfoText(string useInfoText)
        {
            _throwText.text = useInfoText;
        }

        public void SetUseInfoText(string useInfoText)
        {
            _useText.text = useInfoText;
        }

        public void Show()
        {
            _seedInfoCanvas.Show();
        }

        public void Hide()
        {
            _seedInfoCanvas.Hide();
        }
    }
}
