using UnityEngine;

namespace SotongStudio
{
    public interface IPostBattleView
    {
        void Show();
        void Hide();
    }
    public class PostBattleView : MonoBehaviour, IPostBattleView
    {
        [SerializeField]
        private CanvasGroup _mainCanvas;

        public void Hide()
        {
            _mainCanvas.Hide();
        }

        public void Show()
        {
            _mainCanvas.Show();
        }
    }
}
