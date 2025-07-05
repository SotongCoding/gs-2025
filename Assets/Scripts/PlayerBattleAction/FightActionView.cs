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
    }
    public class FightActionView : MonoBehaviour, IFightActionView
    {
        public UnityEvent OnStartQA => _fightButton.onClick;
        public UnityEvent OnSpaceBarAction { get; private set; } = new UnityEvent();   

        [SerializeField]
        private Button _fightButton;

        [SerializeField]
        private CanvasGroup _fightCanvas;

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
            if(Input.GetKeyDown(KeyCode.Space))
            {
                OnSpaceBarAction.Invoke();
            }
        }
    }
}
