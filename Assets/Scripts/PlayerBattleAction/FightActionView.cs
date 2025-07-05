using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace SotongStudio
{
    public interface IFightActionView
    {
        UnityEvent OnStartQA { get; }
        UnityEvent OnSpaceBarAction { get; }
        void Show();
        void Hide();

        void UpdateHealthText(int currentHealth);
    }
    public class FightActionView : MonoBehaviour, IFightActionView
    {
        public UnityEvent OnStartQA => _fightButton.onClick;
        public UnityEvent OnSpaceBarAction { get; private set; } = new UnityEvent();

        [SerializeField]
        private Button _fightButton;

        [SerializeField]
        private CanvasGroup _fightCanvas;

        [SerializeField]
        private TMP_Text _healthText;

        public void Show()
        {
            _fightCanvas.Show();
        }

        public void Hide()
        {
            _fightCanvas.Hide();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                OnSpaceBarAction.Invoke();
            }
        }

        public void UpdateHealthText(int currentHealth)
        {
            _healthText.text = $"Health : {currentHealth.ToString()}";
        }
    }
}
